using FtpLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Open7x0Client
{
    public partial class Form1 : Form
    {
        private MencoderSharp.MencoderAsync mencoderAsync = new MencoderSharp.MencoderAsync();

        private List<Open7x0EncodingQueueEntry> queue;

        public Form1()
        {
            InitializeComponent();
        }

        public List<VdrInfo.InfoVdrParser.InfoVdr> mencoderparamterMetaInfos { get; set; }

        private void buttonDefaultToMp4_Click(object sender, EventArgs e)
        {
            //16:9:
            //-vf yadif,dsize=16/9,scale=-10:-1,harddup -of lavf -lavfopts format=mp4 -ovc x264 -sws 9 -x264encopts nocabac:level_idc=30:bframes=0:bitrate=512:threads=auto:turbo=1:global_header:threads=auto
            //4:3:
            //-vf yadif
            //-oac faac -faacopts mpeg=4:object=2:raw:br=128
            //Experimental 5.1 for mp4:
            //-oac faac -faacopts mpeg=4:object=2:raw:br=256 -channels 6 -aid 128
            textBoxCommand43.Text = "-vf yadif,dsize=4/3,scale=-10:-1,harddup -of lavf -lavfopts format=mp4 -ovc x264 -sws 9 -x264encopts nocabac:level_idc=30:bframes=0:bitrate=512:threads=auto:turbo=1:global_header:threads=auto";
            textBox169.Text = "-vf yadif,dsize=16/9,scale=-10:-1,harddup -of lavf -lavfopts format=mp4 -ovc x264 -sws 9 -x264encopts nocabac:level_idc=30:bframes=0:bitrate=820:threads=auto:turbo=1:global_header:threads=auto";
            textBoxAC3.Text = "-oac faac -faacopts mpeg=4:object=2:raw:br=128 ";
            textBoxStereoMp3.Text = "-oac faac -faacopts mpeg=4:object=2:raw:br=128 ";
            textBoxOutputFileExtension.Text = ".mp4";
            Properties.Settings.Default.Save();
        }

        private void buttonDefaultToXvid_Click(object sender, EventArgs e)
        {
            //4:3:
            //-ovc xvid -xvidencopts bitrate=512:threads=2:aspect=4/3 -vf scale -xy 720
            //16:9:
            //-ovc xvid -xvidencopts bitrate=900:threads=2:aspect=16/9 -vf scale -zoom -xy 720
            //Audio 2ch:
            //-oac mp3lame
            //Audio 5.1:
            //-oac copy -aid 128
            textBoxCommand43.Text = "-ovc xvid -xvidencopts bitrate=512:threads=2:aspect=4/3 -vf yadif,dsize=4/3,scale=-10:-1 ";
            textBox169.Text = "-ovc xvid -xvidencopts bitrate=900:threads=2:aspect=16/9 -vf scale yadif,dsize=16/9,scale=-10:-1 ";
            textBoxAC3.Text = "-oac copy -aid 128 ";
            textBoxStereoMp3.Text = "-oac mp3lame ";
            textBoxOutputFileExtension.Text = ".avi";
            Properties.Settings.Default.Save();
        }

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            tabControl1.Enabled = false;
            try
            {
                using (FtpConnection ftp = new FtpConnection(textBoxBoxAdresse.Text, textBoxUsername.Text, textBoxPassword.Text))
                {
                    ftp.Open(); /* Open the FTP connection */
                    ftp.Login(); /* Login using previously provided credentials */

                    foreach (var item in checkedListBoxRecordings.CheckedItems)
                    {
                        ftp.SetCurrentDirectory(item.ToString());
                        foreach (var item1 in ftp.GetFiles())
                            ftp.RemoveFile(item1.Name);
                        ftp.RemoveDirectory(item.ToString());
                        log("deleted " + item.ToString() + "\n");
                    }
                }
                FindAllVdrInfo_Click(sender, e);
            }
            catch (FtpException ex)
            {
                log2((String.Format("FTP Error: {0} {1}", ex.ErrorCode, ex.Message)));
            }
            catch (Exception ex)
            {
                log2((String.Format("Error: {0}", ex.Message)));
            }
            tabControl1.Enabled = true;
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            queue = new List<Open7x0EncodingQueueEntry>();
            queue.Clear();
            checkedListBoxRecordings.ClearSelected();
            if (checkedListBoxRecordings.CheckedItems.Count > 0)
            {
                buttonEncode.Enabled = false;
                progressBar1.Visible = true;
                var mencoderParameters = new dvbTEncodingInfo { AudioAc3 = textBoxAC3.Text, AudioStero = textBoxStereoMp3.Text, Video169 = textBox169.Text, Video43 = textBoxCommand43.Text };
                foreach (var checkedFilm in checkedListBoxRecordings.CheckedItems)
                {
                    if (pathIsOnFtp(checkedFilm.ToString()))
                        using (FtpConnection ftp = new FtpConnection(textBoxBoxAdresse.Text, textBoxUsername.Text, textBoxPassword.Text))
                        {
                            ftp.Open(); /* Open the FTP connection */
                            ftp.Login(); /* Login using previously provided credentials */
                            log("Converting " + checkedFilm.ToString() + "\n");
                            ftp.SetCurrentDirectory(checkedFilm.ToString());
                            if (ftp.FileExists("001.vdr"))  /* check that a file exists */
                            {
                                log2(checkedFilm.ToString() + " added to queu");
                                var vdrinfo = getVdrInfo(checkedFilm.ToString());

                                queue.Add(new Open7x0EncodingQueueEntry(vdrinfo, mencoderParameters, checkBoxDeleteOnEncoded.Checked, textBoxLocalOutputDirectory.Text, textBoxOutputFilename.Text, textBoxOutputFileExtension.Text));
                            }
                            else
                            {
                                log2("File not found on remote server" + checkedFilm.ToString());
                                buttonEncode.Enabled = true;
                            }
                        }
                    else
                    {
                        if (Directory.GetFiles(checkedFilm.ToString()).Any(o => Path.GetFileName(o) == "001.vdr"))  /* check that a file exists */
                        {
                            log2(checkedFilm.ToString() + " added to queu");
                            var vdrinfo = getVdrInfo(checkedFilm.ToString());
                            queue.Add(new Open7x0EncodingQueueEntry(vdrinfo, mencoderParameters, checkBoxDeleteOnEncoded.Checked, textBoxLocalOutputDirectory.Text, textBoxOutputFilename.Text, textBoxOutputFileExtension.Text));
                        }
                        else
                        {
                            log2("File not found on remote server" + checkedFilm.ToString());
                            buttonEncode.Enabled = true;
                        }
                    }
                }
                if (queue.Count == 0)
                {
                    log("Broken recording, no videofile found");
                }
                else
                {
                    var nextQuedItem = getNextPendingFile(queue, EncodingState.Encoding);
                    log2("Encoding " + nextQuedItem.Titel + " starting (" + nextQuedItem.VdrsPaths.First(o => o.encodingState == EncodingState.Encoding).vdrpath + ")");
                    mencoderAsync.startEncodeAsync(nextQuedItem.VdrsPaths.First(o => o.encodingState == EncodingState.Encoding).vdrpath, nextQuedItem.VdrsPaths.First(o => o.encodingState == EncodingState.Encoding).OutputDestination, nextQuedItem.mencoderparamterVideo, nextQuedItem.mencoderparamterAudio);
                }
            }
            foreach (int i in checkedListBoxRecordings.CheckedIndices)
            {
                checkedListBoxRecordings.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private bool pathIsOnFtp(string v)
        {
            return v.StartsWith(textBoxRemoteRootDirectoryForVideo.Text);
        }

        /// <summary>
        /// Handles the Click event of the buttonPlayWithVlc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonPlayWithVlc_Click(object sender, EventArgs e)
        {
            if (checkedListBoxRecordings.SelectedItem != null)
            {
                string itartingRelativePath = string.Empty;
                string concatedListOfStreamFiles = string.Empty;
                using (FtpConnection ftp = new FtpConnection(textBoxBoxAdresse.Text, textBoxUsername.Text, textBoxPassword.Text))
                {
                    ftp.Open(); /* Open the FTP connection */
                    ftp.Login(); /* Login using previously provided credentials */
                    log("Playing " + checkedListBoxRecordings.SelectedItem.ToString() + "\n");
                    var currentRelativePath = checkedListBoxRecordings.SelectedItem.ToString();
                    var currentDirectoryName = currentRelativePath.Split('/').Last();
                    #region rename nonUnicodedirectory
                    string[] separators = { "/" };
                    foreach (var item in currentRelativePath.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (containsNonUnicode(item))
                        {
                            var newDirName = hackeDirectoryName(item);
                            ftp.SetCurrentDirectory(itartingRelativePath);
                            ftp.RenameFile(item, newDirName);
                            itartingRelativePath += "/" + newDirName;
                        }
                        else
                            itartingRelativePath += "/" + item;
                    }
                    # endregion
                    if (containsNonUnicode(currentDirectoryName))
                    {
                        log("Renaming non unicodedirectory " + currentDirectoryName + "\n");
                        ftp.SetCurrentDirectory(currentRelativePath.Substring(0, currentRelativePath.Length - currentDirectoryName.Length));
                        var newDirName = hackeDirectoryName(currentDirectoryName);
                        log("Renaming non unicodedirectory " + currentDirectoryName + " to " + newDirName + "\n");
                        ftp.RenameFile(currentDirectoryName, newDirName);
                        ftp.SetCurrentDirectory(currentRelativePath.Substring(0, currentRelativePath.Length - newDirName.Length) + newDirName);
                    }
                    ftp.SetCurrentDirectory(itartingRelativePath);
                    if (ftp.FileExists("001.vdr"))  /* check that a file exists */
                    {
                        foreach (var item in ftp.GetFiles())
                        {
                            if (item.Name.EndsWith("vdr") && item.Name.StartsWith("0"))
                            {
                                //hack does not work always...
                                concatedListOfStreamFiles += hackOpenVdrEncoding(new Uri("ftp://" + textBoxBoxAdresse.Text + itartingRelativePath + "/" + item.Name + " ").AbsoluteUri + " ");
                                //concatedListOfStreamFiles += new Uri("ftp://" + textBoxBoxAdresse.Text + checkedListBoxRecordings.SelectedItem.ToString() + "/" + item.Name + " ").AbsoluteUri + " ";
                            }
                        }
                    }
                    else
                        log2("File not found on remote server");
                }
                if (!string.IsNullOrWhiteSpace(concatedListOfStreamFiles))
                {
                    Process p = new Process();
                    //p.StartInfo.WorkingDirectory = @"C:\whatever";
                    p.StartInfo.FileName = textBoxVlcPath.Text;
                    //http://msdn.microsoft.com/de-de/library/system.diagnostics.processstartinfo.redirectstandardoutput.aspx
                    p.StartInfo.Arguments = concatedListOfStreamFiles + " " + textBoxVlcParamters.Text;
                    p.Start();
                }
                if (itartingRelativePath != checkedListBoxRecordings.SelectedItem.ToString())
                {
                    //checkedListBoxRecordings.SelectedItem = itartingRelativePath;
                    FindAllVdrInfo_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void checkedListBoxRecordings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxRecordings.SelectedItem != null)
                propertyGridVdrInfo.SelectedObject = getVdrInfo(checkedListBoxRecordings.SelectedItem.ToString());
        }

        private bool containsNonUnicode(string p)
        {
            //http://stackoverflow.com/questions/123336/how-can-you-strip-non-ascii-characters-from-a-string-in-c
            return Regex.IsMatch(p, @"[^\u0000-\u007F]");
        }

        private void deleteVdrsFromFtp(List<Open7x0EncodingQueueEntry> queue)
        {
            using (FtpConnection ftp = new FtpConnection(textBoxBoxAdresse.Text, textBoxUsername.Text, textBoxPassword.Text))
            {
                foreach (var queueItem in queue.Where(o => o.encodingState == EncodingState.done))
                {
                    ftp.Open(); /* Open the FTP connection */
                    ftp.Login(); /* Login using previously provided credentials */
                    string directoryName = removeSubstringAfterSlash(queueItem.VdrsPaths.First().vdrpath.ToString());
                    directoryName = removeTrailingServername(directoryName, ftp.Host);
                    log2("Deleteing Directory " + directoryName);

                    ftp.SetCurrentDirectory(directoryName);
                    var listOfFiles = ftp.GetFiles();
                    if (listOfFiles.Count() > 0)
                    {
                        log2("Deleting " + directoryName + "\n");
                    }
                    foreach (var item1 in listOfFiles)
                    {
                        ftp.RemoveFile(item1.Name);
                        log("Deleted File " + item1.Name);
                    }
                    ftp.RemoveDirectory(directoryName);
                }
            }
        }

        private void FindAllVdrInfo_Click(object sender, EventArgs e)
        {
            updateVideoList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mencoderAsync.Finished += new System.EventHandler(this.mencoder_Finished);
            mencoderAsync.Progress += new EventHandler(this.mencoder_Progress);
        }

        /// <summary>
        /// Handles the Shown event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            FindAllVdrInfo_Click(sender, e);
        }

        private Open7x0EncodingQueueEntry getNextPendingFile(List<Open7x0EncodingQueueEntry> queue, EncodingState newState)
        {
            if (queue.Any(o => o.encodingState == newState))
                return queue.First(o => o.encodingState == newState);
            else
            {
                queue.First(o => o.encodingState == EncodingState.Qued).encodingState = newState;
                queue.Single(o => o.encodingState == newState).VdrsPaths.First().encodingState = EncodingState.Encoding;
            }
            return queue.First(o => o.encodingState == newState);
        }

        private VdrInfo.InfoVdrParser.InfoVdr getVdrInfo(string currentDirectory)
        {
            var metadata = new VdrInfo.InfoVdrParser.InfoVdr();
            var parser = new VdrInfo.InfoVdrParser();
            metadata.Directory = currentDirectory;
            if (pathIsOnFtp(currentDirectory))
            {
                using (FtpConnection ftp = new FtpConnection(textBoxBoxAdresse.Text, textBoxUsername.Text, textBoxPassword.Text))
                {
                    try
                    {
                        ftp.Open(); /* Open the FTP connection */
                        ftp.Login(); /* Login using previously provided credentials */
                        log("Reading " + currentDirectory + "\n");
                        ftp.SetCurrentDirectory(currentDirectory);
                        if (ftp.FileExists("info.vdr"))  /* check that a file exists */
                        {
                            ftp.GetFile("info.vdr", Path.GetTempPath() + "\\vdr.info", false); /* download /incoming/file.txt as file.txt to current executing directory, overwrite if it exists */
                                                                                               //metadata.infoVdrPath = textBoxLocalWorkingDirectory.Text + "\\vdr.info";
                            metadata = parser.parseInfoVdr(Path.GetTempPath() + "\\vdr.info");
                            log2(metadata.Description);
                            //log2(metadata.Titel + "\n" + metadata.Description + "\n");
                        }
                        else
                            log2("File not found on remote server");
                        foreach (var item in ftp.GetFiles())
                        {
                            if (item.Name.EndsWith("vdr") && item.Name.StartsWith("0"))
                            {
                                metadata.VdrsPaths.Add(new Uri("ftp://" + textBoxBoxAdresse.Text + currentDirectory + "/" + item.Name));
                            }
                        }
                    }
                    catch (FtpException ex)
                    {
                        log2((String.Format("FTP Error: {0} {1}", ex.ErrorCode, ex.Message)));
                    }
                    catch (Exception ex)
                    {
                        log2((String.Format("Error: {0}", ex.Message)));
                    }
                }
            }
            else
            {
                metadata = parser.parseInfoVdr(Path.Combine(currentDirectory, "info.vdr"));
                log2(metadata.Description);
                foreach (var item in Directory.GetFiles(currentDirectory))
                {
                    var filename = Path.GetFileName(item);
                    if (filename.EndsWith("vdr") && filename.StartsWith("0"))
                    {
                        metadata.VdrsPaths.Add(new Uri(Path.Combine(currentDirectory, item)));
                    }
                }
            }
            return metadata;
        }

        private string hackeDirectoryName(string p)
        {
            //http://stackoverflow.com/questions/123336/how-can-you-strip-non-ascii-characters-from-a-string-in-c
            return Regex.Replace(p, @"[^\u0000-\u007F]", string.Empty);
        }

        private string hackOpenVdrEncoding(string p)
        {
            // Workarround for messed up encoding / does not help with vlc
            // ü %C3%BC -> %FC
            // ß %C3%9F -> %DF
            // ö %C3%B6 -> %F6
            // ä %C3%A4 -> %E4
            // # #-> %23
            // Ö %C3%96 -> %D6
            // & & -> %26
            // todo:
            // Ä  %C3%84 -> %C4
            // Ü  %C3%9C -> %DC
            return p.Replace("%C3%9F", "%DF").Replace("%C3%B6", "%F6").Replace("%C3%BC", "%FC").Replace("%C3%A4", "%E4").Replace("#", "%23").Replace("%C3%96", "%D6").Replace("&", "%26").Replace("%C3%84", "%C4").Replace("%C3%9C", "%DC");
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void log(string message)
        {
            Application.OpenForms[0].Text = "Open7x0Client " + message;
            richTextBoxLog.Text += message;
            if (richTextBoxLog.Text.Length > 10000)
            {
                richTextBoxLog.Text = richTextBoxLog.Text.Remove(0, 1000);
            }
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }

        /// <summary>
        /// Log2s the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void log2(string message)
        {
            richTextBox2.Text += message + "\n";
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
            richTextBox2.ScrollToCaret();

            richTextBoxLog.Text += message;
            if (richTextBoxLog.Text.Length > 10000)
            {
                richTextBoxLog.Text = richTextBoxLog.Text.Remove(0, 1000);
            }
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }

        /// <summary>
        /// Handles the Finished event of the mencoder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mencoder_Finished(object sender, EventArgs e)
        {
            if (!mencoderAsync.Result.ExecutionWasSuccessfull)
            {
                var failedFilm = queue.Single(o => o.encodingState == EncodingState.Encoding);
                failedFilm.encodingState = EncodingState.error;
                foreach (var item1 in queue.Where(o => o.encodingState == EncodingState.error))
                    foreach (var item in item1.VdrsPaths)
                    {
                        if (item.encodingState != EncodingState.done)
                            item.encodingState = EncodingState.error;
                    }
                log(mencoderAsync.Result.StandardError);
                log2("Encoding " + failedFilm.Titel + " failed");
            }
            if (queue.Any(o => o.encodingState == EncodingState.Encoding))
            {
                foreach (var lastfinishedItem in queue.Single(o => o.encodingState == EncodingState.Encoding).VdrsPaths.Where(o => o.encodingState == EncodingState.Encoding))
                {
                    lastfinishedItem.encodingState = EncodingState.writingMetadata;
                    writeMetaInfoToMp4(lastfinishedItem.OutputDestination, queue.Single(o => o.encodingState == EncodingState.Encoding));
                    lastfinishedItem.encodingState = EncodingState.readyForConcating;
                }
                //all parts of one film reencoded?
                if (queue.Single(o => o.encodingState == EncodingState.Encoding).VdrsPaths.All(o => o.encodingState == EncodingState.readyForConcating))
                {
                    var queuItemsToConcatinate = queue.Single(o => o.encodingState == EncodingState.Encoding);
                    // and is it a multipartrecord?
                    if (queuItemsToConcatinate.VdrsPaths.Count > 1)
                    {
                        queue.Single(o => o.encodingState == EncodingState.Encoding).encodingState = EncodingState.readyForConcating;
                        //concatination

                        var mp4boxSharp = new mp4boxSharp.mp4BoxSharpSync();
                        var concating = new List<Uri>();
                        queuItemsToConcatinate.encodingState = EncodingState.concating;
                        foreach (var item in queuItemsToConcatinate.VdrsPaths)
                        {
                            concating.Add(item.OutputDestination);
                        }
                        tabControl1.Enabled = false;
                        File.Delete(queuItemsToConcatinate.ConcatedOuptupFilename.LocalPath);
                        if (mp4boxSharp.mp4BoxConcat(concating, queuItemsToConcatinate.ConcatedOuptupFilename))
                        {
                            foreach (var item in concating)
                            {
                                try
                                {
                                    File.Delete(item.LocalPath);
                                }
                                catch (Exception)
                                {
                                    log2("Deleting " + item.AbsolutePath + " failed");
                                }
                            }
                            writeMetaInfoToMp4(queuItemsToConcatinate.ConcatedOuptupFilename, queuItemsToConcatinate);
                        }
                        tabControl1.Enabled = true;
                    }
                    queuItemsToConcatinate.encodingState = EncodingState.done;
                    log2("Encoding " + queuItemsToConcatinate.Titel + " done");
                }
            }
            //is there anything left to reencode?
            if (queue.Where(o => o.encodingState != EncodingState.done).Where(o => o.encodingState != EncodingState.error).Count() > 0)
            {
                var nextQuedItem = getNextPendingFile(queue, EncodingState.Encoding);
                if (nextQuedItem.VdrsPaths.Any(o => o.encodingState == EncodingState.Qued))
                {
                    var nextStreamingFile = nextQuedItem.VdrsPaths.First(o => o.encodingState == EncodingState.Qued);
                    nextStreamingFile.encodingState = EncodingState.Encoding;
                    log2("Encoding " + nextQuedItem.Titel + " starting (" + nextStreamingFile.vdrpath + ")");
                    mencoderAsync.startEncodeAsync(nextStreamingFile.vdrpath, nextStreamingFile.OutputDestination, nextQuedItem.mencoderparamterVideo, nextQuedItem.mencoderparamterAudio);
                }
                else if (nextQuedItem.VdrsPaths.Any(o => o.encodingState == EncodingState.Encoding))
                {
                    var nextStreamingFile = nextQuedItem.VdrsPaths.First(o => o.encodingState == EncodingState.Encoding);
                    nextStreamingFile.encodingState = EncodingState.Encoding;
                    log2("Encoding " + nextQuedItem.Titel + " starting (" + nextStreamingFile.vdrpath + ")");
                    mencoderAsync.startEncodeAsync(nextStreamingFile.vdrpath, nextStreamingFile.OutputDestination, nextQuedItem.mencoderparamterVideo, nextQuedItem.mencoderparamterAudio);
                }
                else
                    postEncoding();
            }
            else
            {
                postEncoding();
            }
        }

        private void mencoder_Progress(object sender, EventArgs e)
        {
            //log2(mencoderAsync.stdOutput);
            progressBar1.Value = mencoderAsync.progress;
        }

        private void postEncoding()
        {
            if (checkBoxDeleteOnEncoded.Checked)
                try
                {
                    deleteVdrsFromFtp(queue);
                    updateVideoList();
                }
                catch (FtpException ex)
                {
                    log2((String.Format("FTP Error: {0} {1}", ex.ErrorCode, ex.Message)));
                }
                catch (Exception ex)
                {
                    log2((String.Format("Error: {0}", ex.Message)));
                }

            tabControl1.Enabled = true;
            buttonEncode.Enabled = true;
            progressBar1.Visible = false;
            if (checkBoxShutdownAfterFinishedEncoding.Checked)
            {
                Process.Start("shutdown", "/h");
            }
        }

        private List<string> recursiveFtpSearch(string filename, FtpConnection ftp, string rootDirectory)
        {
            List<string> filesList = new List<string>();
            try
            {
                //log("Switching to rootdirectory");
                ftp.SetCurrentDirectory(rootDirectory);
                var rootDirectoryInfo = ftp.GetCurrentDirectoryInfo();
                log("Searching in " + rootDirectoryInfo.Name);
                foreach (var directory in rootDirectoryInfo.GetDirectories())
                {
                    if (!directory.Name.EndsWith(".del"))
                    {
                        //log("Verzeichnis: " + rootDirectory + "/" + directory.Name + "\n");
                        ftp.SetCurrentDirectory(rootDirectory + "/" + directory.Name);
                        var files = directory.GetFiles();
                        foreach (var file in files.Where(o => o.Name.Equals(filename)))
                        {
                            //log("Found File: " + rootDirectory + "/" + file.Name + "\n");
                            filesList.Add(rootDirectory + "/" + directory.Name);
                        }
                        //do it recursive:
                        filesList.AddRange(recursiveFtpSearch(filename, ftp, rootDirectory + "/" + directory.Name));
                        ftp.SetCurrentDirectory(rootDirectory);
                    }
                }
            }
            catch (FtpException ex)
            {
                log2((String.Format("FTP Error: {0} {1}", ex.ErrorCode, ex.Message)));
            }
            catch (Exception ex)
            {
                log2((String.Format("Error: {0}", ex.Message)));
            }
            return filesList;
        }

        private string removeSubstringAfterSlash(string p)
        {
            int foo = 0;
            int foundLastIndex = 0;
            foreach (char item in p)
            {
                foo++;
                if (item == '/')
                    foundLastIndex = foo;
            }
            return p.Trim().Remove(foundLastIndex - 1, p.Length - foundLastIndex + 1).Trim();
        }

        private string removeTrailingServername(string directoryName, string p)
        {
            string protocol = "ftp://";
            return directoryName.Remove(0, protocol.Length).Remove(0, p.Length);
        }

        private void updateVideoList()
        {
            checkedListBoxRecordings.Items.Clear();
            updateVideoListLocal();
            if (checkBoxUseFtp.Checked)
            {
                updateVideoListFtp1();
            }
        }

        private void updateVideoListFtp1()
        {
            List<string> filesList = new List<string>();
            log("Connecting to ftpserver");
            using (FtpConnection ftp = new FtpConnection(textBoxBoxAdresse.Text, textBoxUsername.Text, textBoxPassword.Text))
            {
                try
                {
                    log("Open connection");
                    ftp.Open(); /* Open the FTP connection */
                    log("login");
                    ftp.Login(); /* Login using previously provided credentials */
                    filesList = recursiveFtpSearch("info.vdr", ftp, textBoxRemoteRootDirectoryForVideo.Text);
                    log("Finished searching. Found " + filesList.Count.ToString() + " Videos");
                }
                catch (FtpException ex)
                {
                    log2((String.Format("FTP Error: {0} {1}", ex.ErrorCode, ex.Message)));
                }
                catch (Exception ex)
                {
                    log2((String.Format("Error: {0}", ex.Message)));
                }
            }
            checkedListBoxRecordings.Items.AddRange(filesList.ToArray());
        }

        private void writeMetaInfoToMp4(Uri pathToMp4, Open7x0EncodingQueueEntry infoVdr)
        {
            log2("Writing Metainfo to " + pathToMp4.LocalPath);
            for (int i = 0; i < 3; i++)
                try
                {
                    if (File.Exists(pathToMp4.LocalPath))
                    {
                        TagLib.File tagFile = TagLib.File.Create(pathToMp4.LocalPath); // track is the name of the mp3
                        //Title - Title
                        tagFile.Tag.Title = infoVdr.Titel;
                        //Untertitle - Shortdescription
                        tagFile.Tag.TitleSort = infoVdr.ShortDescription;
                        //Kommentar - Comment
                        tagFile.Tag.Comment = infoVdr.Description + "\nChannelID: " + infoVdr.ChannelID + "\nEventID: " + infoVdr.EventID + "\nTimerInfo: " + infoVdr.TimerInfo + "\nVpsInfo: " + infoVdr.VpsInfo + "\nTimerInfo: " + infoVdr.TimerInfo;
                        tagFile.Save();
                    }
                    else
                    {
                        log2("File not found " + pathToMp4.LocalPath);
                    }
                }
                catch (System.IO.IOException e)
                {
                    if (i < 3)
                    {
                        log2("WARNING " + pathToMp4.LocalPath + " is locked");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                        log2("ERROR " + pathToMp4.LocalPath + " is locked, skipped writing metadata");
                }
        }

        private void updateVideoListLocal()
        {
            List<string> filesList = new List<string>();
            log("Connecting to ftpserver");
            try
            {
                filesList = recursiveSearch("info.vdr", textBoxLocalSourceRoot.Text);
                log("Finished local searching. Found " + filesList.Count.ToString() + " Videos");
            }
            catch (Exception ex)
            {
                log2((String.Format("Error: {0}", ex.Message)));
            }
            checkedListBoxRecordings.Items.AddRange(filesList.ToArray());
        }

        private List<string> recursiveSearch(string filename, string rootDirectory)
        {
            List<string> filesList = new List<string>();
            try
            {
                foreach (var directory in Directory.GetDirectories(rootDirectory))
                {
                    var files = Directory.GetFiles(directory);
                    foreach (var file in files.Where(o => Path.GetFileName(o) == filename))
                    {
                        filesList.Add(Path.Combine(rootDirectory, directory));
                    }
                    filesList.AddRange(recursiveSearch(filename, Path.Combine(rootDirectory, directory)));
                }
            }
            catch (Exception ex)
            {
                log2((String.Format("Error: {0}", ex.Message)));
            }
            return filesList;
        }
    }
}