using System.Diagnostics;
using vid2contactsheet.DownloadClient;

namespace vid2contactsheet.Forms
{
    public partial class FrmBinaryDownloader : Form
    {
        public FrmBinaryDownloader()
        {
            InitializeComponent();
        }

        private void BtnManual_Click(object sender, EventArgs e)
        {
            Process.Start(
                new ProcessStartInfo($"https://github.com/McKenzie-Software/vid2contactsheet/wiki/Manual-Download")
                {
                    UseShellExecute = true
                }
            );

            this.Close();
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            BtnDownload.Enabled = false;
            BtnManual.Enabled = false;

            // resize form to show progress bar
            this.Size = new Size(818, 473);

            // configure progress
            var progress = new Progress<int>(percent =>
            {
                progressBarDownload.Value = percent;
            });

            // start the downloader client
            Downloader downloader = new();

            UpdateDownloadNotice($"Downloading ffmpeg");
            await downloader.DownloadPackage("https://github.com/ffbinaries/ffbinaries-prebuilt/releases/download/v6.1/ffmpeg-6.1-win-64.zip", "ffmpeg", progress).ConfigureAwait(false);
            ResetProgressBar();

            UpdateDownloadNotice($"Downloading ffprobe");
            await downloader.DownloadPackage("https://github.com/ffbinaries/ffbinaries-prebuilt/releases/download/v6.1/ffprobe-6.1-win-64.zip", "ffprobe", progress).ConfigureAwait(false);
            ResetProgressBar();

            UpdateDownloadNotice($"Downloading ImageMagick");
            await downloader.DownloadPackage("https://imagemagick.org/archive/binaries/ImageMagick-7.1.1-37-portable-Q16-x64.zip", "imagemagick", progress).ConfigureAwait(false);
            // don't reset the last one since we're finished

            // rename the imagemagick directory
            Directory.Move(@"bin/ImageMagick-7.1.1-37-portable-Q16-x64", "bin/imagemagick");

            // Close form and open main form
            this.Invoke(new Action(() => this.Close()));
        }

        private void UpdateDownloadNotice(string notice)
        {
            if(LblDownloadNotice.InvokeRequired)
            {
                LblDownloadNotice.Invoke(new Action(() =>
                {
                    LblDownloadNotice.Text = notice;
                }));
            }
            else
            {
                LblDownloadNotice.Text = notice;
            }
        }

        private void ResetProgressBar()
        {
            if (progressBarDownload.InvokeRequired)
            {
                progressBarDownload.Invoke(new Action(() =>
                {
                    progressBarDownload.Value = 0;
                }));
            } else
            {
                progressBarDownload.Value = 0;
            }
        }
    }
}
