namespace vid2contactsheet.Forms
{
    partial class FrmBinaryDownloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBinaryDownloader));
            LblNotice = new Label();
            BtnDownload = new Button();
            BtnManual = new Button();
            progressBarDownload = new ProgressBar();
            LblDownloadNotice = new Label();
            SuspendLayout();
            // 
            // LblNotice
            // 
            LblNotice.BorderStyle = BorderStyle.FixedSingle;
            LblNotice.Location = new Point(20, 20);
            LblNotice.Name = "LblNotice";
            LblNotice.Size = new Size(768, 294);
            LblNotice.TabIndex = 0;
            LblNotice.Text = resources.GetString("LblNotice.Text");
            // 
            // BtnDownload
            // 
            BtnDownload.Location = new Point(20, 317);
            BtnDownload.Name = "BtnDownload";
            BtnDownload.Size = new Size(300, 29);
            BtnDownload.TabIndex = 1;
            BtnDownload.Text = "Automatic Download";
            BtnDownload.UseVisualStyleBackColor = true;
            BtnDownload.Click += BtnDownload_Click;
            // 
            // BtnManual
            // 
            BtnManual.Location = new Point(488, 317);
            BtnManual.Name = "BtnManual";
            BtnManual.Size = new Size(300, 29);
            BtnManual.TabIndex = 2;
            BtnManual.Text = "Manual Download";
            BtnManual.UseVisualStyleBackColor = true;
            BtnManual.Click += BtnManual_Click;
            // 
            // progressBarDownload
            // 
            progressBarDownload.Location = new Point(20, 379);
            progressBarDownload.Name = "progressBarDownload";
            progressBarDownload.Size = new Size(768, 29);
            progressBarDownload.TabIndex = 3;
            // 
            // LblDownloadNotice
            // 
            LblDownloadNotice.AutoSize = true;
            LblDownloadNotice.Location = new Point(20, 356);
            LblDownloadNotice.Name = "LblDownloadNotice";
            LblDownloadNotice.Size = new Size(0, 20);
            LblDownloadNotice.TabIndex = 4;
            // 
            // FrmBinaryDownloader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 358);
            Controls.Add(LblDownloadNotice);
            Controls.Add(progressBarDownload);
            Controls.Add(BtnManual);
            Controls.Add(BtnDownload);
            Controls.Add(LblNotice);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmBinaryDownloader";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Executable Downloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblNotice;
        private Button BtnDownload;
        private Button BtnManual;
        private ProgressBar progressBarDownload;
        private Label LblDownloadNotice;
    }
}