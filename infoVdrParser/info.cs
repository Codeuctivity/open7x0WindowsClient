using System;
using System.Collections.Generic;
using System.Text;

//http://www.vdr-wiki.de/wiki/index.php/Info.vdr
namespace VdrInfo
{
    public class InfoVdrParser
    {
        public InfoVdr parseInfoVdr(string path)
        {
            string info = ReadFromFile(path);
            string[] seperator = new string[] { "\n" };
            InfoVdr infoVdr = new InfoVdr();
            infoVdr.infoVdrPath = path;
            foreach (string row in info.Split(seperator, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!(row.Length < 2))
                {
                    switch (row.Substring(0, 2))
                    {
                        case "C ":
                            infoVdr.ChannelID = row.Substring(2);
                            break;

                        case "E ":
                            infoVdr.EventID = row.Substring(2);
                            break;

                        case "T ":
                            infoVdr.Titel = row.Substring(2).Replace('|', '\n');
                            break;

                        case "S ":
                            infoVdr.ShortDescription = row.Substring(2).Replace('|', '\n');
                            break;

                        case "D ":
                            infoVdr.Description = row.Substring(2).Replace('|', '\n');
                            break;

                        case "X ":
                            if (row.Substring(2, 1) == "1")
                            {
                                string Videoinfo = row.Substring(3);
                                infoVdr.RawVideostreaminfos.Add(Videoinfo);
                                //01 = 05 = 4:3, 02 = 03 = 06 = 07 = 16:9, 04 = 08 = >16:9, 09 = 0D = HD 4:3, 0A = 0B = 0E = 0F = HD 16:9, 0C = 10 = HD >16:9
                                if (Videoinfo.Contains("01") || Videoinfo.Contains("05") || Videoinfo.Contains("09") || Videoinfo.Contains("0D"))
                                {
                                    //4:3
                                    infoVdr.VideoWidthHeightRatios.Add(VideoWidthHeightRatio.NormalTv);
                                }
                                else if (Videoinfo.Contains("02") || Videoinfo.Contains("03") || Videoinfo.Contains("06") || Videoinfo.Contains("07") || Videoinfo.Contains("04") || Videoinfo.Contains("08") || Videoinfo.Contains("0C") || Videoinfo.Contains("10") || Videoinfo.Contains("0A") || Videoinfo.Contains("0B") || Videoinfo.Contains("0E") || Videoinfo.Contains("0F"))
                                {
                                    //16:9
                                    infoVdr.VideoWidthHeightRatios.Add(VideoWidthHeightRatio.Widescreen);
                                }
                                else
                                {
                                    //unknown ratio
                                    infoVdr.VideoWidthHeightRatios.Add(VideoWidthHeightRatio.Unknown);
                                }
                            }
                            else if (row.Substring(2, 1) == "2")
                            {
                                string Audioinfo = row.Substring(3);
                                infoVdr.RawAudiostreaminfos.Add(Audioinfo);
                                //01 = Mono?, 03 = Stereo, 05 = Dolby Digital

                                #region channelquantity

                                switch (Audioinfo.Trim().Substring(0, 2))
                                {
                                    case "01":
                                        //Mono
                                        infoVdr.AudioChannels.Add(AudioChannel.Mono);
                                        break;

                                    case "03":
                                        //Stereo
                                        infoVdr.AudioChannels.Add(AudioChannel.Stereo);
                                        break;

                                    case "05":
                                        //Dolby  - in most cases just stereo
                                        if (Audioinfo.Trim().Contains("2."))
                                            infoVdr.AudioChannels.Add(AudioChannel.Stereo);
                                        else if (Audioinfo.Trim().Contains("5."))
                                            infoVdr.AudioChannels.Add(AudioChannel.Surround);
                                        else if (Audioinfo.Trim().Contains("1."))
                                            infoVdr.AudioChannels.Add(AudioChannel.Mono);
                                        else if (Audioinfo.Trim().Contains("4."))
                                            infoVdr.AudioChannels.Add(AudioChannel.Surround);
                                        else if (Audioinfo.Trim().Contains("Dolby Digital"))
                                            infoVdr.AudioChannels.Add(AudioChannel.Surround);
                                        else
                                            infoVdr.AudioChannels.Add(AudioChannel.Unknown);
                                        break;

                                    default:
                                        //unknown
                                        infoVdr.AudioChannels.Add(AudioChannel.Unknown);
                                        break;
                                }

                                #endregion channelquantity

                                //deu=german, eng=english

                                #region channelLanguage

                                if (Audioinfo.Trim().ToLower().Contains("deu") || Audioinfo.Trim().ToLower().Contains("ger"))
                                {
                                    infoVdr.AudioLanguages.Add(AudioLanguage.German);
                                }
                                else if (Audioinfo.Trim().ToLower().Contains("eng"))
                                {
                                    infoVdr.AudioLanguages.Add(AudioLanguage.English);
                                }
                                else
                                {
                                    infoVdr.AudioLanguages.Add(AudioLanguage.Other);
                                }

                                #endregion channelLanguage
                            }
                            else
                                infoVdr.Unknowninfos.Add(row);
                            break;

                        case "V ":
                            infoVdr.VpsInfo = row.Substring(2);
                            break;

                        case "@ ":
                            infoVdr.TimerInfo = row.Substring(2);
                            break;

                        default:
                            infoVdr.Unknowninfos.Add(row.Replace('|', '\n'));
                            break;
                    }
                }
            }
            return infoVdr;
        }

        /// <summary>
        /// Holds the metadata of a record, see http://www.vdr-wiki.de/wiki/index.php/Info.vdr
        /// </summary>
        public class InfoVdr
        {
            public InfoVdr()
            {
                VdrsPaths = new List<Uri>();
            }

            /// <summary>
            /// Path of the parsed metadata file
            /// </summary>
            public string infoVdrPath { get; set; }

            /// <summary>
            /// Paths of corresponding vdr files containing the ps stream
            /// </summary>
            public List<Uri> VdrsPaths { get; set; }

            /// <summary>
            /// ChannelId of recorded video - see channel.conf
            /// </summary>
            public string ChannelID { get; set; }

            /// <summary>
            /// EventId
            /// </summary>
            public string EventID { get; set; }

            /// <summary>
            /// Title of film
            /// </summary>
            public string Titel { get; set; }

            /// <summary>
            /// A short description of the film
            /// </summary>
            public string ShortDescription { get; set; }

            /// <summary>
            /// Information about the containing ratio of height and width of the image
            /// </summary>
            private List<string> rawvideostreaminfos = new List<string>();

            public List<string> RawVideostreaminfos
            {
                get { return rawvideostreaminfos; }
                set { rawvideostreaminfos = value; }
            }

            /// <summary>
            /// Information about the containing ratio of height and width of the image
            /// </summary>
            private List<VideoWidthHeightRatio> videoWidthHeightRatios = new List<VideoWidthHeightRatio>();

            public List<VideoWidthHeightRatio> VideoWidthHeightRatios
            {
                get { return videoWidthHeightRatios; }
                set { videoWidthHeightRatios = value; }
            }

            /// <summary>
            /// contains long description of film
            /// </summary>
            public string Description { get; set; }

            private List<string> rawaudiostreaminfos = new List<string>();

            /// <summary>
            /// contains data of audiostreaminfo, possible values: Mono, Stereo, Surround
            /// </summary>
            public List<AudioChannel> AudioChannels
            {
                get { return audioChannels; }
                set { audioChannels = value; }
            }

            private List<AudioChannel> audioChannels = new List<AudioChannel>();

            /// <summary>
            /// conatains languages of film
            /// </summary>
            public List<AudioLanguage> AudioLanguages
            {
                get { return audioLanguages; }
                set { audioLanguages = value; }
            }

            private List<AudioLanguage> audioLanguages = new List<AudioLanguage>();

            /// <summary>
            /// contains raw data of audiostreaminfo, possible values: 01 = Mono?, 03 = Stereo, 05 = Dolby Digital
            /// </summary>
            public List<string> RawAudiostreaminfos
            {
                get { return rawaudiostreaminfos; }
                set { rawaudiostreaminfos = value; }
            }

            private List<string> unknowninfos = new List<string>();

            /// <summary>
            /// contains raw data of unrecognized information
            /// </summary>
            public List<string> Unknowninfos
            {
                get { return unknowninfos; }
                set { unknowninfos = value; }
            }

            /// <summary>
            /// contains setted time from VPS
            /// </summary>
            public string VpsInfo { get; set; }

            /// <summary>
            /// contains information which was set by the timer (see timer.conf)
            /// </summary>
            public string TimerInfo { get; set; }

            /// <summary>
            /// Gets or sets the directory.
            /// </summary>
            /// <value>
            /// The directory containing streamingfiles and metadatafile.
            /// </value>
            public string Directory { get; set; }
        }

        private static string ReadFromFile(string filename)
        {
            //http://www.csharphelp.com/archives/archive24.html
            //correct encoding
            //http://msdn.microsoft.com/en-us/library/cc488003.aspx
            System.IO.StreamReader SR = new System.IO.StreamReader(filename, Encoding.Default);
            string Ret = "";
            string S;
            S = SR.ReadLine();
            while (S != null)
            {
                Ret = Ret + S + "\n";
                S = SR.ReadLine();
            }
            SR.Close();
            return Ret;
        }

        public enum VideoWidthHeightRatio { Widescreen, NormalTv, Unknown };

        public enum AudioLanguage { German, English, Other };

        public enum AudioChannel { Mono, Stereo, Surround, Unknown };
    }
}