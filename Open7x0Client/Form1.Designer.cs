namespace Open7x0Client
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkedListBoxRecordings = new System.Windows.Forms.CheckedListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.propertyGridVdrInfo = new System.Windows.Forms.PropertyGrid();
            this.buttonPlayWithVlc = new System.Windows.Forms.Button();
            this.FindAllVdrInfo = new System.Windows.Forms.Button();
            this.buttonDeleteSelected = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDefaultToMp4 = new System.Windows.Forms.Button();
            this.buttonDefaultToXvid = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxOutputFilename = new System.Windows.Forms.TextBox();
            this.textBoxOutputFileExtension = new System.Windows.Forms.TextBox();
            this.checkBoxDeleteOnEncoded = new System.Windows.Forms.CheckBox();
            this.textBoxCommand43 = new System.Windows.Forms.TextBox();
            this.textBox169 = new System.Windows.Forms.TextBox();
            this.textBoxAC3 = new System.Windows.Forms.TextBox();
            this.textBoxStereoMp3 = new System.Windows.Forms.TextBox();
            this.checkBoxUseFtp = new System.Windows.Forms.CheckBox();
            this.textBoxLocalSourceRoot = new System.Windows.Forms.TextBox();
            this.checkBoxShutdownAfterFinishedEncoding = new System.Windows.Forms.CheckBox();
            this.textBoxVlcParamters = new System.Windows.Forms.TextBox();
            this.textBoxVlcPath = new System.Windows.Forms.TextBox();
            this.textBoxLocalOutputDirectory = new System.Windows.Forms.TextBox();
            this.textBoxRemoteRootDirectoryForVideo = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxBoxAdresse = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1011, 693);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1003, 667);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxRecordings);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox2);
            this.splitContainer1.Panel2.Controls.Add(this.buttonEncode);
            this.splitContainer1.Panel2.Controls.Add(this.propertyGridVdrInfo);
            this.splitContainer1.Panel2.Controls.Add(this.buttonPlayWithVlc);
            this.splitContainer1.Panel2.Controls.Add(this.FindAllVdrInfo);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDeleteSelected);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(997, 661);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 18;
            // 
            // checkedListBoxRecordings
            // 
            this.checkedListBoxRecordings.CheckOnClick = true;
            this.checkedListBoxRecordings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxRecordings.FormattingEnabled = true;
            this.checkedListBoxRecordings.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxRecordings.Name = "checkedListBoxRecordings";
            this.checkedListBoxRecordings.Size = new System.Drawing.Size(500, 661);
            this.checkedListBoxRecordings.TabIndex = 10;
            this.checkedListBoxRecordings.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxRecordings_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 611);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(493, 21);
            this.progressBar1.TabIndex = 25;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox2.HideSelection = false;
            this.richTextBox2.Location = new System.Drawing.Point(0, 401);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(493, 210);
            this.richTextBox2.TabIndex = 24;
            this.richTextBox2.Text = "";
            // 
            // buttonEncode
            // 
            this.buttonEncode.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEncode.Location = new System.Drawing.Point(0, 380);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(493, 21);
            this.buttonEncode.TabIndex = 22;
            this.buttonEncode.Text = "Encode";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // propertyGridVdrInfo
            // 
            this.propertyGridVdrInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridVdrInfo.Location = new System.Drawing.Point(0, 63);
            this.propertyGridVdrInfo.Name = "propertyGridVdrInfo";
            this.propertyGridVdrInfo.Size = new System.Drawing.Size(493, 317);
            this.propertyGridVdrInfo.TabIndex = 19;
            // 
            // buttonPlayWithVlc
            // 
            this.buttonPlayWithVlc.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPlayWithVlc.Location = new System.Drawing.Point(0, 42);
            this.buttonPlayWithVlc.Name = "buttonPlayWithVlc";
            this.buttonPlayWithVlc.Size = new System.Drawing.Size(493, 21);
            this.buttonPlayWithVlc.TabIndex = 20;
            this.buttonPlayWithVlc.Text = "Play with vlc";
            this.buttonPlayWithVlc.UseVisualStyleBackColor = true;
            this.buttonPlayWithVlc.Click += new System.EventHandler(this.buttonPlayWithVlc_Click);
            // 
            // FindAllVdrInfo
            // 
            this.FindAllVdrInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.FindAllVdrInfo.Location = new System.Drawing.Point(0, 21);
            this.FindAllVdrInfo.Name = "FindAllVdrInfo";
            this.FindAllVdrInfo.Size = new System.Drawing.Size(493, 21);
            this.FindAllVdrInfo.TabIndex = 18;
            this.FindAllVdrInfo.Text = "Refresh";
            this.FindAllVdrInfo.UseVisualStyleBackColor = true;
            this.FindAllVdrInfo.Click += new System.EventHandler(this.FindAllVdrInfo_Click);
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDeleteSelected.Location = new System.Drawing.Point(0, 0);
            this.buttonDeleteSelected.Name = "buttonDeleteSelected";
            this.buttonDeleteSelected.Size = new System.Drawing.Size(493, 21);
            this.buttonDeleteSelected.TabIndex = 21;
            this.buttonDeleteSelected.Text = "Delete Selected";
            this.buttonDeleteSelected.UseVisualStyleBackColor = true;
            this.buttonDeleteSelected.Click += new System.EventHandler(this.buttonDeleteSelected_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonDefaultToMp4);
            this.tabPage2.Controls.Add(this.buttonDefaultToXvid);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.richTextBoxLog);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.buttonSave);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1003, 667);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Config";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDefaultToMp4
            // 
            this.buttonDefaultToMp4.Location = new System.Drawing.Point(696, 435);
            this.buttonDefaultToMp4.Name = "buttonDefaultToMp4";
            this.buttonDefaultToMp4.Size = new System.Drawing.Size(121, 23);
            this.buttonDefaultToMp4.TabIndex = 39;
            this.buttonDefaultToMp4.Text = "Preset to h264 / Mp4";
            this.buttonDefaultToMp4.UseVisualStyleBackColor = true;
            this.buttonDefaultToMp4.Click += new System.EventHandler(this.buttonDefaultToMp4_Click);
            // 
            // buttonDefaultToXvid
            // 
            this.buttonDefaultToXvid.Location = new System.Drawing.Point(569, 435);
            this.buttonDefaultToXvid.Name = "buttonDefaultToXvid";
            this.buttonDefaultToXvid.Size = new System.Drawing.Size(121, 23);
            this.buttonDefaultToXvid.TabIndex = 38;
            this.buttonDefaultToXvid.Text = "Preset to Xvid / Avi";
            this.buttonDefaultToXvid.UseVisualStyleBackColor = true;
            this.buttonDefaultToXvid.Click += new System.EventHandler(this.buttonDefaultToXvid_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(488, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(487, 419);
            this.richTextBox1.TabIndex = 37;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxLog.HideSelection = false;
            this.richTextBoxLog.Location = new System.Drawing.Point(3, 470);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(997, 194);
            this.richTextBoxLog.TabIndex = 36;
            this.richTextBoxLog.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxOutputFilename);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.textBoxOutputFileExtension);
            this.groupBox3.Controls.Add(this.checkBoxDeleteOnEncoded);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBoxCommand43);
            this.groupBox3.Controls.Add(this.textBox169);
            this.groupBox3.Controls.Add(this.textBoxAC3);
            this.groupBox3.Controls.Add(this.textBoxStereoMp3);
            this.groupBox3.Location = new System.Drawing.Point(9, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 203);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mencoder Settings";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "Output Filename";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "Output File extension";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Audio 5.1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Audio 2Ch";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Video 4:3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Video 16:9";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(488, 435);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxUseFtp);
            this.groupBox4.Controls.Add(this.textBoxLocalSourceRoot);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.checkBoxShutdownAfterFinishedEncoding);
            this.groupBox4.Controls.Add(this.textBoxVlcParamters);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBoxVlcPath);
            this.groupBox4.Controls.Add(this.textBoxLocalOutputDirectory);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.textBoxRemoteRootDirectoryForVideo);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textBoxPassword);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBoxUsername);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBoxBoxAdresse);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(8, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(471, 249);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Main Settings";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "VLC Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Vdr-Adresse";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Outputdirectory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "VLC Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ftp- Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ftp Kennwort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Remote Videoroot";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 201);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Local Sourceroot";
            // 
            // textBoxOutputFilename
            // 
            this.textBoxOutputFilename.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "mencoderOutputFilename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxOutputFilename.Location = new System.Drawing.Point(112, 149);
            this.textBoxOutputFilename.Name = "textBoxOutputFilename";
            this.textBoxOutputFilename.Size = new System.Drawing.Size(343, 20);
            this.textBoxOutputFilename.TabIndex = 56;
            this.textBoxOutputFilename.Text = global::Open7x0Client.Properties.Settings.Default.mencoderOutputFilename;
            // 
            // textBoxOutputFileExtension
            // 
            this.textBoxOutputFileExtension.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "mencoderOutputFileExtension", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxOutputFileExtension.Location = new System.Drawing.Point(112, 123);
            this.textBoxOutputFileExtension.Name = "textBoxOutputFileExtension";
            this.textBoxOutputFileExtension.Size = new System.Drawing.Size(343, 20);
            this.textBoxOutputFileExtension.TabIndex = 53;
            this.textBoxOutputFileExtension.Text = global::Open7x0Client.Properties.Settings.Default.mencoderOutputFileExtension;
            // 
            // checkBoxDeleteOnEncoded
            // 
            this.checkBoxDeleteOnEncoded.AutoSize = true;
            this.checkBoxDeleteOnEncoded.Checked = global::Open7x0Client.Properties.Settings.Default.DeleteOnEncoded;
            this.checkBoxDeleteOnEncoded.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Open7x0Client.Properties.Settings.Default, "DeleteOnEncoded", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDeleteOnEncoded.Location = new System.Drawing.Point(6, 180);
            this.checkBoxDeleteOnEncoded.Name = "checkBoxDeleteOnEncoded";
            this.checkBoxDeleteOnEncoded.Size = new System.Drawing.Size(182, 17);
            this.checkBoxDeleteOnEncoded.TabIndex = 52;
            this.checkBoxDeleteOnEncoded.Text = "Delete After successfull encoded";
            this.checkBoxDeleteOnEncoded.UseVisualStyleBackColor = true;
            // 
            // textBoxCommand43
            // 
            this.textBoxCommand43.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "mencoder4to3Parameter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxCommand43.Location = new System.Drawing.Point(112, 19);
            this.textBoxCommand43.Name = "textBoxCommand43";
            this.textBoxCommand43.Size = new System.Drawing.Size(343, 20);
            this.textBoxCommand43.TabIndex = 44;
            this.textBoxCommand43.Text = global::Open7x0Client.Properties.Settings.Default.mencoder4to3Parameter;
            // 
            // textBox169
            // 
            this.textBox169.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "mencoder16to9Parameter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox169.Location = new System.Drawing.Point(112, 45);
            this.textBox169.Name = "textBox169";
            this.textBox169.Size = new System.Drawing.Size(343, 20);
            this.textBox169.TabIndex = 45;
            this.textBox169.Text = global::Open7x0Client.Properties.Settings.Default.mencoder16to9Parameter;
            // 
            // textBoxAC3
            // 
            this.textBoxAC3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "mencoderSurroundParameter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxAC3.Location = new System.Drawing.Point(112, 97);
            this.textBoxAC3.Name = "textBoxAC3";
            this.textBoxAC3.Size = new System.Drawing.Size(343, 20);
            this.textBoxAC3.TabIndex = 47;
            this.textBoxAC3.Text = global::Open7x0Client.Properties.Settings.Default.mencoderSurroundParameter;
            // 
            // textBoxStereoMp3
            // 
            this.textBoxStereoMp3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "mencoderStereoParameter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxStereoMp3.Location = new System.Drawing.Point(112, 71);
            this.textBoxStereoMp3.Name = "textBoxStereoMp3";
            this.textBoxStereoMp3.Size = new System.Drawing.Size(343, 20);
            this.textBoxStereoMp3.TabIndex = 46;
            this.textBoxStereoMp3.Text = global::Open7x0Client.Properties.Settings.Default.mencoderStereoParameter;
            // 
            // checkBoxUseFtp
            // 
            this.checkBoxUseFtp.AutoSize = true;
            this.checkBoxUseFtp.Checked = global::Open7x0Client.Properties.Settings.Default.UseFtp;
            this.checkBoxUseFtp.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Open7x0Client.Properties.Settings.Default, "UseFtp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxUseFtp.Location = new System.Drawing.Point(197, 226);
            this.checkBoxUseFtp.Name = "checkBoxUseFtp";
            this.checkBoxUseFtp.Size = new System.Drawing.Size(63, 17);
            this.checkBoxUseFtp.TabIndex = 22;
            this.checkBoxUseFtp.Text = "Use Ftp";
            this.checkBoxUseFtp.UseVisualStyleBackColor = true;
            // 
            // textBoxLocalSourceRoot
            // 
            this.textBoxLocalSourceRoot.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "localWorkingDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxLocalSourceRoot.Location = new System.Drawing.Point(113, 198);
            this.textBoxLocalSourceRoot.Name = "textBoxLocalSourceRoot";
            this.textBoxLocalSourceRoot.Size = new System.Drawing.Size(343, 20);
            this.textBoxLocalSourceRoot.TabIndex = 21;
            this.textBoxLocalSourceRoot.Text = global::Open7x0Client.Properties.Settings.Default.localWorkingDirectory;
            // 
            // checkBoxShutdownAfterFinishedEncoding
            // 
            this.checkBoxShutdownAfterFinishedEncoding.AutoSize = true;
            this.checkBoxShutdownAfterFinishedEncoding.Checked = global::Open7x0Client.Properties.Settings.Default.ShutdownAfterEncodingFinished;
            this.checkBoxShutdownAfterFinishedEncoding.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Open7x0Client.Properties.Settings.Default, "ShutdownAfterEncodingFinished", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxShutdownAfterFinishedEncoding.Location = new System.Drawing.Point(9, 226);
            this.checkBoxShutdownAfterFinishedEncoding.Name = "checkBoxShutdownAfterFinishedEncoding";
            this.checkBoxShutdownAfterFinishedEncoding.Size = new System.Drawing.Size(182, 17);
            this.checkBoxShutdownAfterFinishedEncoding.TabIndex = 19;
            this.checkBoxShutdownAfterFinishedEncoding.Text = "Hibernate after finished encoding";
            this.checkBoxShutdownAfterFinishedEncoding.UseVisualStyleBackColor = true;
            // 
            // textBoxVlcParamters
            // 
            this.textBoxVlcParamters.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "vlcParameters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxVlcParamters.Location = new System.Drawing.Point(113, 143);
            this.textBoxVlcParamters.Name = "textBoxVlcParamters";
            this.textBoxVlcParamters.Size = new System.Drawing.Size(343, 20);
            this.textBoxVlcParamters.TabIndex = 18;
            this.textBoxVlcParamters.Text = global::Open7x0Client.Properties.Settings.Default.vlcParameters;
            // 
            // textBoxVlcPath
            // 
            this.textBoxVlcPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "vlcPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxVlcPath.Location = new System.Drawing.Point(113, 117);
            this.textBoxVlcPath.Name = "textBoxVlcPath";
            this.textBoxVlcPath.Size = new System.Drawing.Size(343, 20);
            this.textBoxVlcPath.TabIndex = 7;
            this.textBoxVlcPath.Text = global::Open7x0Client.Properties.Settings.Default.vlcPath;
            // 
            // textBoxLocalOutputDirectory
            // 
            this.textBoxLocalOutputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "localWorkingDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxLocalOutputDirectory.Location = new System.Drawing.Point(113, 169);
            this.textBoxLocalOutputDirectory.Name = "textBoxLocalOutputDirectory";
            this.textBoxLocalOutputDirectory.Size = new System.Drawing.Size(343, 20);
            this.textBoxLocalOutputDirectory.TabIndex = 10;
            this.textBoxLocalOutputDirectory.Text = global::Open7x0Client.Properties.Settings.Default.localWorkingDirectory;
            // 
            // textBoxRemoteRootDirectoryForVideo
            // 
            this.textBoxRemoteRootDirectoryForVideo.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "remoteVideoRoot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxRemoteRootDirectoryForVideo.Location = new System.Drawing.Point(113, 91);
            this.textBoxRemoteRootDirectoryForVideo.Name = "textBoxRemoteRootDirectoryForVideo";
            this.textBoxRemoteRootDirectoryForVideo.Size = new System.Drawing.Size(343, 20);
            this.textBoxRemoteRootDirectoryForVideo.TabIndex = 6;
            this.textBoxRemoteRootDirectoryForVideo.Text = global::Open7x0Client.Properties.Settings.Default.remoteVideoRoot;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "ftpPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxPassword.Location = new System.Drawing.Point(113, 65);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(343, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.Text = global::Open7x0Client.Properties.Settings.Default.ftpPassword;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "ftpUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxUsername.Location = new System.Drawing.Point(113, 39);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(343, 20);
            this.textBoxUsername.TabIndex = 2;
            this.textBoxUsername.Text = global::Open7x0Client.Properties.Settings.Default.ftpUsername;
            // 
            // textBoxBoxAdresse
            // 
            this.textBoxBoxAdresse.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Open7x0Client.Properties.Settings.Default, "serveradress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxBoxAdresse.Location = new System.Drawing.Point(113, 13);
            this.textBoxBoxAdresse.Name = "textBoxBoxAdresse";
            this.textBoxBoxAdresse.Size = new System.Drawing.Size(343, 20);
            this.textBoxBoxAdresse.TabIndex = 1;
            this.textBoxBoxAdresse.Text = global::Open7x0Client.Properties.Settings.Default.serveradress;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 693);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Open7x0Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBoxAdresse;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxRemoteRootDirectoryForVideo;
        private System.Windows.Forms.TextBox textBoxVlcPath;
        private System.Windows.Forms.TextBox textBoxLocalOutputDirectory;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxCommand43;
        private System.Windows.Forms.TextBox textBox169;
        private System.Windows.Forms.TextBox textBoxAC3;
        private System.Windows.Forms.TextBox textBoxStereoMp3;
        private System.Windows.Forms.TextBox textBoxVlcParamters;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxDeleteOnEncoded;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxOutputFileExtension;
        private System.Windows.Forms.TextBox textBoxOutputFilename;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox checkedListBoxRecordings;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.PropertyGrid propertyGridVdrInfo;
        private System.Windows.Forms.Button buttonPlayWithVlc;
        private System.Windows.Forms.Button FindAllVdrInfo;
        private System.Windows.Forms.Button buttonDeleteSelected;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBoxShutdownAfterFinishedEncoding;
        private System.Windows.Forms.Button buttonDefaultToMp4;
        private System.Windows.Forms.Button buttonDefaultToXvid;
        private System.Windows.Forms.CheckBox checkBoxUseFtp;
        private System.Windows.Forms.TextBox textBoxLocalSourceRoot;
        private System.Windows.Forms.Label label14;
    }
}

