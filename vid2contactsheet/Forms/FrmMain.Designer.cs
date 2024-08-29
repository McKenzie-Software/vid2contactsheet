namespace vid2contactsheet
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            TxtFilePath = new TextBox();
            BtnFilePath = new Button();
            tabCtrl = new TabControl();
            tabConfiguration = new TabPage();
            LblCompressContactSheetResolution = new Label();
            TxtCompressContactSheetResolution = new TextBox();
            CbCompressContactSheet = new CheckBox();
            LblCompressContactSheet = new Label();
            BtnStart = new Button();
            LblConfigureFrameCountNotice = new Label();
            numericFrameCount = new NumericUpDown();
            LblConfigureFrameCount = new Label();
            LblConfigureMagickExecutableValue = new Label();
            LblConfigureFfprobeExecutableValue = new Label();
            LblConfigureFfmpegExecutableValue = new Label();
            LblConfigureOutputDirectoryValue = new Label();
            LblConfigureAnnotatedDirectoryValue = new Label();
            LblConfigureFrameDirectoryValue = new Label();
            LblConfigureMagickExecutable = new Label();
            LblConfigureFfprobeExecutable = new Label();
            LblConfigureFfmpegExecutable = new Label();
            LblConfigureOutputDirectory = new Label();
            LblConfigureAnnotatedDirectory = new Label();
            LblConfigureFrameDirectory = new Label();
            LblConfigureFilePath = new Label();
            tabPreview = new TabPage();
            LblPreviewPleaseWait = new Label();
            BtnVideoPreviewNext = new Button();
            LblCurrentSnapshotPreview = new Label();
            PbVideoPreview = new PictureBox();
            tabContactSheet = new TabPage();
            BtnOutputDirectory = new Button();
            BtnGenerateContactSheet = new Button();
            LblContactSheetPleaseWait = new Label();
            PbContactSheet = new PictureBox();
            tabGifGenerator = new TabPage();
            BtnOutputDirectoryGif = new Button();
            LblGifPleaseWait = new Label();
            PbGifPreview = new PictureBox();
            BtnGenerateGif = new Button();
            BtnLicenses = new Button();
            BtnAbout = new Button();
            tabCtrl.SuspendLayout();
            tabConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericFrameCount).BeginInit();
            tabPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbVideoPreview).BeginInit();
            tabContactSheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbContactSheet).BeginInit();
            tabGifGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbGifPreview).BeginInit();
            SuspendLayout();
            // 
            // TxtFilePath
            // 
            TxtFilePath.Location = new Point(239, 40);
            TxtFilePath.Name = "TxtFilePath";
            TxtFilePath.Size = new Size(714, 27);
            TxtFilePath.TabIndex = 1;
            // 
            // BtnFilePath
            // 
            BtnFilePath.Location = new Point(959, 40);
            BtnFilePath.Name = "BtnFilePath";
            BtnFilePath.Size = new Size(36, 29);
            BtnFilePath.TabIndex = 2;
            BtnFilePath.Text = "...";
            BtnFilePath.UseVisualStyleBackColor = true;
            BtnFilePath.Click += BtnFilePath_ClickAsync;
            // 
            // tabCtrl
            // 
            tabCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabCtrl.Controls.Add(tabConfiguration);
            tabCtrl.Controls.Add(tabPreview);
            tabCtrl.Controls.Add(tabContactSheet);
            tabCtrl.Controls.Add(tabGifGenerator);
            tabCtrl.Location = new Point(0, 36);
            tabCtrl.Name = "tabCtrl";
            tabCtrl.SelectedIndex = 0;
            tabCtrl.Size = new Size(1276, 787);
            tabCtrl.TabIndex = 3;
            tabCtrl.SelectedIndexChanged += tabCtrl_SelectedIndexChanged;
            // 
            // tabConfiguration
            // 
            tabConfiguration.BackColor = Color.White;
            tabConfiguration.Controls.Add(LblCompressContactSheetResolution);
            tabConfiguration.Controls.Add(TxtCompressContactSheetResolution);
            tabConfiguration.Controls.Add(CbCompressContactSheet);
            tabConfiguration.Controls.Add(LblCompressContactSheet);
            tabConfiguration.Controls.Add(BtnStart);
            tabConfiguration.Controls.Add(LblConfigureFrameCountNotice);
            tabConfiguration.Controls.Add(numericFrameCount);
            tabConfiguration.Controls.Add(BtnFilePath);
            tabConfiguration.Controls.Add(LblConfigureFrameCount);
            tabConfiguration.Controls.Add(TxtFilePath);
            tabConfiguration.Controls.Add(LblConfigureMagickExecutableValue);
            tabConfiguration.Controls.Add(LblConfigureFfprobeExecutableValue);
            tabConfiguration.Controls.Add(LblConfigureFfmpegExecutableValue);
            tabConfiguration.Controls.Add(LblConfigureOutputDirectoryValue);
            tabConfiguration.Controls.Add(LblConfigureAnnotatedDirectoryValue);
            tabConfiguration.Controls.Add(LblConfigureFrameDirectoryValue);
            tabConfiguration.Controls.Add(LblConfigureMagickExecutable);
            tabConfiguration.Controls.Add(LblConfigureFfprobeExecutable);
            tabConfiguration.Controls.Add(LblConfigureFfmpegExecutable);
            tabConfiguration.Controls.Add(LblConfigureOutputDirectory);
            tabConfiguration.Controls.Add(LblConfigureAnnotatedDirectory);
            tabConfiguration.Controls.Add(LblConfigureFrameDirectory);
            tabConfiguration.Controls.Add(LblConfigureFilePath);
            tabConfiguration.Location = new Point(4, 29);
            tabConfiguration.Name = "tabConfiguration";
            tabConfiguration.Padding = new Padding(3);
            tabConfiguration.Size = new Size(1268, 754);
            tabConfiguration.TabIndex = 1;
            tabConfiguration.Text = "Configuration";
            // 
            // LblCompressContactSheetResolution
            // 
            LblCompressContactSheetResolution.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCompressContactSheetResolution.Location = new Point(297, 360);
            LblCompressContactSheetResolution.Name = "LblCompressContactSheetResolution";
            LblCompressContactSheetResolution.Size = new Size(90, 20);
            LblCompressContactSheetResolution.TabIndex = 20;
            LblCompressContactSheetResolution.Text = "Resolution:";
            LblCompressContactSheetResolution.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TxtCompressContactSheetResolution
            // 
            TxtCompressContactSheetResolution.Enabled = false;
            TxtCompressContactSheetResolution.Location = new Point(393, 357);
            TxtCompressContactSheetResolution.Name = "TxtCompressContactSheetResolution";
            TxtCompressContactSheetResolution.Size = new Size(437, 27);
            TxtCompressContactSheetResolution.TabIndex = 19;
            TxtCompressContactSheetResolution.Leave += TxtCompressContactSheetResolution_Leave;
            // 
            // CbCompressContactSheet
            // 
            CbCompressContactSheet.AutoSize = true;
            CbCompressContactSheet.Location = new Point(239, 360);
            CbCompressContactSheet.Name = "CbCompressContactSheet";
            CbCompressContactSheet.Size = new Size(52, 24);
            CbCompressContactSheet.TabIndex = 18;
            CbCompressContactSheet.Text = "Yes";
            CbCompressContactSheet.UseVisualStyleBackColor = true;
            CbCompressContactSheet.CheckedChanged += CbCompressContactSheet_CheckedChanged;
            // 
            // LblCompressContactSheet
            // 
            LblCompressContactSheet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCompressContactSheet.Location = new Point(20, 360);
            LblCompressContactSheet.Name = "LblCompressContactSheet";
            LblCompressContactSheet.Size = new Size(202, 20);
            LblCompressContactSheet.TabIndex = 17;
            LblCompressContactSheet.Text = "Compress Contact Sheet:";
            LblCompressContactSheet.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BtnStart
            // 
            BtnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnStart.Location = new Point(1156, 717);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(94, 29);
            BtnStart.TabIndex = 4;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_ClickAsync;
            // 
            // LblConfigureFrameCountNotice
            // 
            LblConfigureFrameCountNotice.AutoSize = true;
            LblConfigureFrameCountNotice.Location = new Point(498, 315);
            LblConfigureFrameCountNotice.Name = "LblConfigureFrameCountNotice";
            LblConfigureFrameCountNotice.Size = new Size(332, 20);
            LblConfigureFrameCountNotice.TabIndex = 16;
            LblConfigureFrameCountNotice.Text = "The generated contact sheet is 4 frames in width.";
            // 
            // numericFrameCount
            // 
            numericFrameCount.Location = new Point(239, 313);
            numericFrameCount.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            numericFrameCount.Name = "numericFrameCount";
            numericFrameCount.Size = new Size(244, 27);
            numericFrameCount.TabIndex = 15;
            numericFrameCount.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // LblConfigureFrameCount
            // 
            LblConfigureFrameCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblConfigureFrameCount.Location = new Point(20, 320);
            LblConfigureFrameCount.Name = "LblConfigureFrameCount";
            LblConfigureFrameCount.Size = new Size(202, 20);
            LblConfigureFrameCount.TabIndex = 14;
            LblConfigureFrameCount.Text = "Frame Count:";
            LblConfigureFrameCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblConfigureMagickExecutableValue
            // 
            LblConfigureMagickExecutableValue.AutoSize = true;
            LblConfigureMagickExecutableValue.Font = new Font("Segoe UI", 9F);
            LblConfigureMagickExecutableValue.Location = new Point(239, 280);
            LblConfigureMagickExecutableValue.Name = "LblConfigureMagickExecutableValue";
            LblConfigureMagickExecutableValue.Size = new Size(24, 20);
            LblConfigureMagickExecutableValue.TabIndex = 13;
            LblConfigureMagickExecutableValue.Text = ".....";
            // 
            // LblConfigureFfprobeExecutableValue
            // 
            LblConfigureFfprobeExecutableValue.AutoSize = true;
            LblConfigureFfprobeExecutableValue.Font = new Font("Segoe UI", 9F);
            LblConfigureFfprobeExecutableValue.Location = new Point(239, 240);
            LblConfigureFfprobeExecutableValue.Name = "LblConfigureFfprobeExecutableValue";
            LblConfigureFfprobeExecutableValue.Size = new Size(24, 20);
            LblConfigureFfprobeExecutableValue.TabIndex = 12;
            LblConfigureFfprobeExecutableValue.Text = ".....";
            // 
            // LblConfigureFfmpegExecutableValue
            // 
            LblConfigureFfmpegExecutableValue.AutoSize = true;
            LblConfigureFfmpegExecutableValue.Font = new Font("Segoe UI", 9F);
            LblConfigureFfmpegExecutableValue.Location = new Point(239, 200);
            LblConfigureFfmpegExecutableValue.Name = "LblConfigureFfmpegExecutableValue";
            LblConfigureFfmpegExecutableValue.Size = new Size(24, 20);
            LblConfigureFfmpegExecutableValue.TabIndex = 11;
            LblConfigureFfmpegExecutableValue.Text = ".....";
            // 
            // LblConfigureOutputDirectoryValue
            // 
            LblConfigureOutputDirectoryValue.AutoSize = true;
            LblConfigureOutputDirectoryValue.Font = new Font("Segoe UI", 9F);
            LblConfigureOutputDirectoryValue.Location = new Point(239, 160);
            LblConfigureOutputDirectoryValue.Name = "LblConfigureOutputDirectoryValue";
            LblConfigureOutputDirectoryValue.Size = new Size(24, 20);
            LblConfigureOutputDirectoryValue.TabIndex = 10;
            LblConfigureOutputDirectoryValue.Text = ".....";
            // 
            // LblConfigureAnnotatedDirectoryValue
            // 
            LblConfigureAnnotatedDirectoryValue.AutoSize = true;
            LblConfigureAnnotatedDirectoryValue.Font = new Font("Segoe UI", 9F);
            LblConfigureAnnotatedDirectoryValue.Location = new Point(239, 120);
            LblConfigureAnnotatedDirectoryValue.Name = "LblConfigureAnnotatedDirectoryValue";
            LblConfigureAnnotatedDirectoryValue.Size = new Size(24, 20);
            LblConfigureAnnotatedDirectoryValue.TabIndex = 9;
            LblConfigureAnnotatedDirectoryValue.Text = ".....";
            // 
            // LblConfigureFrameDirectoryValue
            // 
            LblConfigureFrameDirectoryValue.AutoSize = true;
            LblConfigureFrameDirectoryValue.Font = new Font("Segoe UI", 9F);
            LblConfigureFrameDirectoryValue.Location = new Point(239, 80);
            LblConfigureFrameDirectoryValue.Name = "LblConfigureFrameDirectoryValue";
            LblConfigureFrameDirectoryValue.Size = new Size(24, 20);
            LblConfigureFrameDirectoryValue.TabIndex = 8;
            LblConfigureFrameDirectoryValue.Text = ".....";
            // 
            // LblConfigureMagickExecutable
            // 
            LblConfigureMagickExecutable.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblConfigureMagickExecutable.Location = new Point(20, 280);
            LblConfigureMagickExecutable.Name = "LblConfigureMagickExecutable";
            LblConfigureMagickExecutable.Size = new Size(202, 20);
            LblConfigureMagickExecutable.TabIndex = 7;
            LblConfigureMagickExecutable.Text = "ImageMagick Executable:";
            LblConfigureMagickExecutable.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblConfigureFfprobeExecutable
            // 
            LblConfigureFfprobeExecutable.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblConfigureFfprobeExecutable.Location = new Point(20, 240);
            LblConfigureFfprobeExecutable.Name = "LblConfigureFfprobeExecutable";
            LblConfigureFfprobeExecutable.Size = new Size(202, 20);
            LblConfigureFfprobeExecutable.TabIndex = 6;
            LblConfigureFfprobeExecutable.Text = "ffprobe Executable:";
            LblConfigureFfprobeExecutable.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblConfigureFfmpegExecutable
            // 
            LblConfigureFfmpegExecutable.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblConfigureFfmpegExecutable.Location = new Point(20, 200);
            LblConfigureFfmpegExecutable.Name = "LblConfigureFfmpegExecutable";
            LblConfigureFfmpegExecutable.Size = new Size(202, 20);
            LblConfigureFfmpegExecutable.TabIndex = 5;
            LblConfigureFfmpegExecutable.Text = "ffmpeg Executable:";
            LblConfigureFfmpegExecutable.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblConfigureOutputDirectory
            // 
            LblConfigureOutputDirectory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblConfigureOutputDirectory.Location = new Point(20, 160);
            LblConfigureOutputDirectory.Name = "LblConfigureOutputDirectory";
            LblConfigureOutputDirectory.Size = new Size(202, 20);
            LblConfigureOutputDirectory.TabIndex = 4;
            LblConfigureOutputDirectory.Text = "Output Directory:";
            LblConfigureOutputDirectory.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblConfigureAnnotatedDirectory
            // 
            LblConfigureAnnotatedDirectory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblConfigureAnnotatedDirectory.Location = new Point(20, 120);
            LblConfigureAnnotatedDirectory.Name = "LblConfigureAnnotatedDirectory";
            LblConfigureAnnotatedDirectory.Size = new Size(202, 20);
            LblConfigureAnnotatedDirectory.TabIndex = 3;
            LblConfigureAnnotatedDirectory.Text = "Annotated Directory:";
            LblConfigureAnnotatedDirectory.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblConfigureFrameDirectory
            // 
            LblConfigureFrameDirectory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblConfigureFrameDirectory.Location = new Point(20, 80);
            LblConfigureFrameDirectory.Name = "LblConfigureFrameDirectory";
            LblConfigureFrameDirectory.Size = new Size(202, 20);
            LblConfigureFrameDirectory.TabIndex = 2;
            LblConfigureFrameDirectory.Text = "Frame Directory:";
            LblConfigureFrameDirectory.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblConfigureFilePath
            // 
            LblConfigureFilePath.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblConfigureFilePath.Location = new Point(20, 40);
            LblConfigureFilePath.Name = "LblConfigureFilePath";
            LblConfigureFilePath.Size = new Size(202, 20);
            LblConfigureFilePath.TabIndex = 0;
            LblConfigureFilePath.Text = "File Path:";
            LblConfigureFilePath.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabPreview
            // 
            tabPreview.BackColor = Color.White;
            tabPreview.Controls.Add(LblPreviewPleaseWait);
            tabPreview.Controls.Add(BtnVideoPreviewNext);
            tabPreview.Controls.Add(LblCurrentSnapshotPreview);
            tabPreview.Controls.Add(PbVideoPreview);
            tabPreview.Location = new Point(4, 29);
            tabPreview.Name = "tabPreview";
            tabPreview.Padding = new Padding(3);
            tabPreview.Size = new Size(1268, 754);
            tabPreview.TabIndex = 0;
            tabPreview.Text = "Preview";
            // 
            // LblPreviewPleaseWait
            // 
            LblPreviewPleaseWait.Location = new Point(3, 298);
            LblPreviewPleaseWait.Name = "LblPreviewPleaseWait";
            LblPreviewPleaseWait.Size = new Size(1262, 22);
            LblPreviewPleaseWait.TabIndex = 5;
            LblPreviewPleaseWait.Text = "Generating Preview. Large files may take longer.";
            LblPreviewPleaseWait.TextAlign = ContentAlignment.MiddleCenter;
            LblPreviewPleaseWait.Visible = false;
            // 
            // BtnVideoPreviewNext
            // 
            BtnVideoPreviewNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnVideoPreviewNext.Location = new Point(1156, 717);
            BtnVideoPreviewNext.Name = "BtnVideoPreviewNext";
            BtnVideoPreviewNext.Size = new Size(94, 29);
            BtnVideoPreviewNext.TabIndex = 1;
            BtnVideoPreviewNext.Text = "Next";
            BtnVideoPreviewNext.UseVisualStyleBackColor = true;
            BtnVideoPreviewNext.Click += BtnVideoPreviewNext_Click;
            // 
            // LblCurrentSnapshotPreview
            // 
            LblCurrentSnapshotPreview.Dock = DockStyle.Bottom;
            LblCurrentSnapshotPreview.Location = new Point(3, 714);
            LblCurrentSnapshotPreview.Name = "LblCurrentSnapshotPreview";
            LblCurrentSnapshotPreview.Size = new Size(1262, 37);
            LblCurrentSnapshotPreview.TabIndex = 2;
            LblCurrentSnapshotPreview.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PbVideoPreview
            // 
            PbVideoPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PbVideoPreview.Location = new Point(3, 3);
            PbVideoPreview.Name = "PbVideoPreview";
            PbVideoPreview.Size = new Size(1262, 708);
            PbVideoPreview.SizeMode = PictureBoxSizeMode.Zoom;
            PbVideoPreview.TabIndex = 0;
            PbVideoPreview.TabStop = false;
            // 
            // tabContactSheet
            // 
            tabContactSheet.BackColor = Color.White;
            tabContactSheet.Controls.Add(BtnOutputDirectory);
            tabContactSheet.Controls.Add(BtnGenerateContactSheet);
            tabContactSheet.Controls.Add(LblContactSheetPleaseWait);
            tabContactSheet.Controls.Add(PbContactSheet);
            tabContactSheet.Location = new Point(4, 29);
            tabContactSheet.Name = "tabContactSheet";
            tabContactSheet.Padding = new Padding(3);
            tabContactSheet.Size = new Size(1268, 754);
            tabContactSheet.TabIndex = 2;
            tabContactSheet.Text = "Generate Contact Sheet";
            // 
            // BtnOutputDirectory
            // 
            BtnOutputDirectory.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnOutputDirectory.Location = new Point(1057, 717);
            BtnOutputDirectory.Name = "BtnOutputDirectory";
            BtnOutputDirectory.Size = new Size(94, 29);
            BtnOutputDirectory.TabIndex = 9;
            BtnOutputDirectory.Text = "Output";
            BtnOutputDirectory.UseVisualStyleBackColor = true;
            BtnOutputDirectory.Click += BtnOutputDirectory_Click;
            // 
            // BtnGenerateContactSheet
            // 
            BtnGenerateContactSheet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnGenerateContactSheet.Location = new Point(1157, 717);
            BtnGenerateContactSheet.Name = "BtnGenerateContactSheet";
            BtnGenerateContactSheet.Size = new Size(94, 29);
            BtnGenerateContactSheet.TabIndex = 8;
            BtnGenerateContactSheet.Text = "Generate";
            BtnGenerateContactSheet.UseVisualStyleBackColor = true;
            BtnGenerateContactSheet.Click += BtnGenerateContactSheet_Click;
            // 
            // LblContactSheetPleaseWait
            // 
            LblContactSheetPleaseWait.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LblContactSheetPleaseWait.Location = new Point(3, 298);
            LblContactSheetPleaseWait.Name = "LblContactSheetPleaseWait";
            LblContactSheetPleaseWait.Size = new Size(1262, 22);
            LblContactSheetPleaseWait.TabIndex = 7;
            LblContactSheetPleaseWait.Text = "Generating Contact Sheet. Large files may take longer.";
            LblContactSheetPleaseWait.TextAlign = ContentAlignment.MiddleCenter;
            LblContactSheetPleaseWait.Visible = false;
            // 
            // PbContactSheet
            // 
            PbContactSheet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PbContactSheet.Location = new Point(3, 3);
            PbContactSheet.Name = "PbContactSheet";
            PbContactSheet.Size = new Size(1262, 708);
            PbContactSheet.SizeMode = PictureBoxSizeMode.Zoom;
            PbContactSheet.TabIndex = 6;
            PbContactSheet.TabStop = false;
            // 
            // tabGifGenerator
            // 
            tabGifGenerator.BackColor = Color.White;
            tabGifGenerator.Controls.Add(BtnOutputDirectoryGif);
            tabGifGenerator.Controls.Add(LblGifPleaseWait);
            tabGifGenerator.Controls.Add(PbGifPreview);
            tabGifGenerator.Controls.Add(BtnGenerateGif);
            tabGifGenerator.Location = new Point(4, 29);
            tabGifGenerator.Name = "tabGifGenerator";
            tabGifGenerator.Padding = new Padding(3);
            tabGifGenerator.Size = new Size(1268, 754);
            tabGifGenerator.TabIndex = 3;
            tabGifGenerator.Text = "Generate Gif";
            // 
            // BtnOutputDirectoryGif
            // 
            BtnOutputDirectoryGif.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnOutputDirectoryGif.Location = new Point(1057, 717);
            BtnOutputDirectoryGif.Name = "BtnOutputDirectoryGif";
            BtnOutputDirectoryGif.Size = new Size(94, 29);
            BtnOutputDirectoryGif.TabIndex = 12;
            BtnOutputDirectoryGif.Text = "Output";
            BtnOutputDirectoryGif.UseVisualStyleBackColor = true;
            BtnOutputDirectoryGif.Click += BtnOutputDirectory_Click;
            // 
            // LblGifPleaseWait
            // 
            LblGifPleaseWait.Location = new Point(3, 298);
            LblGifPleaseWait.Name = "LblGifPleaseWait";
            LblGifPleaseWait.Size = new Size(1262, 22);
            LblGifPleaseWait.TabIndex = 11;
            LblGifPleaseWait.Text = "Generating Gif. Please wait.";
            LblGifPleaseWait.TextAlign = ContentAlignment.MiddleCenter;
            LblGifPleaseWait.Visible = false;
            // 
            // PbGifPreview
            // 
            PbGifPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PbGifPreview.Location = new Point(3, 3);
            PbGifPreview.Name = "PbGifPreview";
            PbGifPreview.Size = new Size(1262, 708);
            PbGifPreview.SizeMode = PictureBoxSizeMode.Zoom;
            PbGifPreview.TabIndex = 10;
            PbGifPreview.TabStop = false;
            // 
            // BtnGenerateGif
            // 
            BtnGenerateGif.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnGenerateGif.Location = new Point(1157, 717);
            BtnGenerateGif.Name = "BtnGenerateGif";
            BtnGenerateGif.Size = new Size(94, 29);
            BtnGenerateGif.TabIndex = 0;
            BtnGenerateGif.Text = "Generate";
            BtnGenerateGif.UseVisualStyleBackColor = true;
            BtnGenerateGif.Click += BtnGenerateGif_Click;
            // 
            // BtnLicenses
            // 
            BtnLicenses.Location = new Point(1170, 12);
            BtnLicenses.Name = "BtnLicenses";
            BtnLicenses.Size = new Size(94, 29);
            BtnLicenses.TabIndex = 4;
            BtnLicenses.Text = "Licenses";
            BtnLicenses.UseVisualStyleBackColor = true;
            BtnLicenses.Click += BtnLicenses_Click;
            // 
            // BtnAbout
            // 
            BtnAbout.Location = new Point(1070, 12);
            BtnAbout.Name = "BtnAbout";
            BtnAbout.Size = new Size(94, 29);
            BtnAbout.TabIndex = 5;
            BtnAbout.Text = "About";
            BtnAbout.UseVisualStyleBackColor = true;
            BtnAbout.Click += BtnAbout_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1276, 823);
            Controls.Add(BtnAbout);
            Controls.Add(BtnLicenses);
            Controls.Add(tabCtrl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "vid2contactsheet - beta! - https://github.com/McKenzie-Software/vid2contactsheet";
            tabCtrl.ResumeLayout(false);
            tabConfiguration.ResumeLayout(false);
            tabConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericFrameCount).EndInit();
            tabPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PbVideoPreview).EndInit();
            tabContactSheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PbContactSheet).EndInit();
            tabGifGenerator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PbGifPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox TxtFilePath;
        private Button BtnFilePath;
        private TabControl tabCtrl;
        private TabPage tabPreview;
        private TabPage tabConfiguration;
        private Button BtnVideoPreviewNext;
        private PictureBox PbVideoPreview;
        private Label LblCurrentSnapshotPreview;
        private Label LblConfigureFfprobeExecutable;
        private Label LblConfigureFfmpegExecutable;
        private Label LblConfigureOutputDirectory;
        private Label LblConfigureAnnotatedDirectory;
        private Label LblConfigureFrameDirectory;
        private Label LblConfigureFilePath;
        private Label LblConfigureMagickExecutableValue;
        private Label LblConfigureFfprobeExecutableValue;
        private Label LblConfigureFfmpegExecutableValue;
        private Label LblConfigureOutputDirectoryValue;
        private Label LblConfigureAnnotatedDirectoryValue;
        private Label LblConfigureFrameDirectoryValue;
        private Label LblConfigureMagickExecutable;
        private Button BtnStart;
        private Label LblPreviewPleaseWait;
        private NumericUpDown numericFrameCount;
        private Label LblConfigureFrameCount;
        private Label LblConfigureFrameCountNotice;
        private TabPage tabContactSheet;
        private Label LblContactSheetPleaseWait;
        private PictureBox PbContactSheet;
        private Button BtnGenerateContactSheet;
        private Button BtnOutputDirectory;
        private TabPage tabGifGenerator;
        private Button BtnGenerateGif;
        private Button BtnOutputDirectoryGif;
        private Label LblGifPleaseWait;
        private PictureBox PbGifPreview;
        private Button BtnLicenses;
        private Button BtnAbout;
        private CheckBox CbCompressContactSheet;
        private Label LblCompressContactSheet;
        private Label LblCompressContactSheetResolution;
        private TextBox TxtCompressContactSheetResolution;
    }
}
