using Laim.LazyLogger;
using System.Diagnostics;
using System.DirectoryServices.Protocols;
using vid2contactsheet.Forms;
using vid2contactsheet.Helpers;

namespace vid2contactsheet
{
    public partial class FrmMain : Form
    {
        private string _tempDirectory;
        private string _tempPathForFile = string.Empty;
        private MediaDirectoryCreator? _creator;
        private int _currentPreviewIndex = 0;
        private bool _canChangeTabs = false;

        public FrmMain(string tempDirectory)
        {
            _tempDirectory ??= tempDirectory;

            InitializeComponent();

            if (!Directory.Exists("bin"))
            {
                FrmBinaryDownloader frmBinaryDownloader = new();
                frmBinaryDownloader.ShowDialog();
            }

            this.Show();
        }

        private void BtnFilePath_ClickAsync(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Video Files|*.mp4;*.mkv;*.avi;*.mov;*.wmv;*.flv;*.mpeg;*.mpg|All Files|*.*",
                Title = "Select a Video File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TxtFilePath.Text = openFileDialog.FileName;
                _canChangeTabs = false;
            }
        }

        private void BtnVideoPreviewNext_Click(object sender, EventArgs e)
        {
            UpdatePreviewPictureBox();
        }

        private async void BtnStart_ClickAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtFilePath.Text))
            {
                MessageBox.Show("Please select a file path.", "File Path Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabCtrl.SelectedIndex = 0;
            ActionRunning(true);

            var fileName = Path.GetFileNameWithoutExtension(TxtFilePath.Text);

            // EXAMPLE: C:\Users\laim\AppData\Local\Temp\vid2contactsheet\VID_28032024
            _tempPathForFile = Path.Combine(_tempDirectory, fileName);

            // create new MediaDirectoryCreator to create the directories for our scan
            _creator = new(_tempPathForFile);
            _creator.CreateStructure();

            // run our powershell script for Preview Thumbnails
            string previewScript = Path.Combine(@"powershell", "04_generate_snapshot_previews.ps1");

            UpdateConfigurationTab();

            try
            {
                PowerShellRunnerPipeline psPipe = new();

                var psParameters = new Dictionary<string, object>()
                {
                    {"ffmpegPath", LblConfigureFfmpegExecutableValue.Text },
                    {"ffprobePath", LblConfigureFfprobeExecutableValue.Text },
                    {"videoFilePath", TxtFilePath.Text },
                    {"outputDirectory", _creator.PREVIEW_DIRECTORY }
                };

                string result = await psPipe.RunPowerShellScript(previewScript, psParameters);

                //MessageBox.Show("Preview generated, full details available in logs.", Text, MessageBoxButtons.OK);

                _currentPreviewIndex = 0;
                UpdatePreviewPictureBox();

                ActionRunning(false);
                _canChangeTabs = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LazyLogger.Fatal<FrmMain>($"{ex}");
                return;
            }
        }

        private async void BtnGenerateContactSheet_Click(object sender, EventArgs e)
        {

            ActionRunning(true);
            DeleteFilesFromDirectories();

            // run our powershell script for complete contact sheet
            string runnerScript = Path.Combine(@"powershell", "00_runner.ps1");

            try
            {
                PowerShellRunnerPipeline psPipe = new();

                var psParameters = new Dictionary<string, object>()
                {
                    {"ffmpegPath", LblConfigureFfmpegExecutableValue.Text },
                    {"ffprobePath", LblConfigureFfprobeExecutableValue.Text },
                    {"videoFilePath", TxtFilePath.Text },
                    {"outputDirectory", _creator.OUTPUT_DIRECTORY },
                    {"frameDirectory", _creator.FRAME_DIRECTORY },
                    {"annotatedFrameDirectory", _creator.ANNOTATED_FRAME_DIRECTORY },
                    {"frameCount", numericFrameCount.Value },
                    {"imageMagickPath", LblConfigureMagickExecutableValue.Text }
                };

                if (CbCompressContactSheet.Checked)
                {
                    psParameters.Add("contactSheetResolution", TxtCompressContactSheetResolution.Text);
                }

                //string test = $"{runnerScript} -ffmpegPath \"{LblConfigureFfmpegExecutableValue.Text}\" -ffprobePath \"{LblConfigureFfprobeExecutableValue.Text}\" -videoFilePath \"{TxtFilePath.Text}\" -outputDirectory \"{_creator.OUTPUT_DIRECTORY}\" -frameDirectory \"{_creator.FRAME_DIRECTORY}\" -annotatedFrameDirectory \"{_creator.ANNOTATED_FRAME_DIRECTORY}\" -frameCount {numericFrameCount.Value} -imageMagickPath \"{LblConfigureMagickExecutableValue.Text}\" -resolution \"{TxtCompressContactSheetResolution.Text}\"";
                //Clipboard.SetText(test);

                string result = await psPipe.RunPowerShellScript(runnerScript, psParameters);

                //MessageBox.Show("Contact Sheet generated, full details available in logs.", Text, MessageBoxButtons.OK);

                UpdateContactSheetPictureBox();

                ActionRunning(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LazyLogger.Fatal<FrmMain>($"{ex}");
                BtnGenerateContactSheet.Enabled = true;
                ActionRunning(false);
                return;
            }
        }

        private void BtnOutputDirectory_Click(object sender, EventArgs e)
        {
            Process.Start(
                new ProcessStartInfo(_creator.OUTPUT_DIRECTORY)
                {
                    UseShellExecute = true
                }
            );
        }

        private async void BtnGenerateGif_Click(object sender, EventArgs e)
        {
            ActionRunning(true);

            if (File.Exists(Path.Combine(_creator.OUTPUT_DIRECTORY, "generated_preview.gif")))
            {
                LazyLogger.Information<FrmMain>($"Generated gif already exists, deleting before proceeding");
                File.Delete(Path.Combine(_creator.OUTPUT_DIRECTORY, "generated_preview.gif"));
            }

            // run our powershell script for complete contact sheet
            string runnerScript = Path.Combine(@"powershell", "05_generate_gif.ps1");

            try
            {
                PowerShellRunnerPipeline psPipe = new();

                var psParameters = new Dictionary<string, object>()
                {
                    {"ffmpegPath", LblConfigureFfmpegExecutableValue.Text },
                    {"ffprobePath", LblConfigureFfprobeExecutableValue.Text },
                    {"videoFilePath", TxtFilePath.Text },
                    {"outputDirectory", _creator.OUTPUT_DIRECTORY },
                    {"length", 10 }
                };

                string result = await psPipe.RunPowerShellScript(runnerScript, psParameters);

                //MessageBox.Show("Gif generated, full details available in logs.", Text, MessageBoxButtons.OK);

                UpdateGifPictureBox();

                ActionRunning(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LazyLogger.Fatal<FrmMain>($"{ex}");
                return;
            }

        }

        /// <summary>
        /// Updates are user-visible labels on the Configuration Tab with the parameter paths etc. 
        /// </summary>
        private void UpdateConfigurationTab()
        {
            var binDirectory = Path.Combine(Directory.GetCurrentDirectory(), "bin");

            LblConfigureFrameDirectoryValue.Text = _creator.FRAME_DIRECTORY;
            LblConfigureAnnotatedDirectoryValue.Text = _creator.ANNOTATED_FRAME_DIRECTORY;
            LblConfigureOutputDirectoryValue.Text = _creator.OUTPUT_DIRECTORY;
            LblConfigureFfmpegExecutableValue.Text = Path.Combine(binDirectory, "ffmpeg.exe");
            LblConfigureFfprobeExecutableValue.Text = Path.Combine(binDirectory, "ffprobe.exe");
            LblConfigureMagickExecutableValue.Text = Path.Combine(binDirectory, "imagemagick", "magick.exe");
        }

        /// <summary>
        /// Updates the Preview Picturebox, called after a successful run.
        /// </summary>
        private void UpdatePreviewPictureBox()
        {
            if (_creator == null)
            {
                MessageBox.Show("MediaCreator is null, something catastrophic has gone wrong.", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Increment the Preview index
            _currentPreviewIndex++;

            // If the index exceeds the number of Previews, reset it to 1
            if (_currentPreviewIndex > 3)
            {
                _currentPreviewIndex = 1;
            }

            // Update the PictureBox with the next Preview
            string previewName = $"Preview{_currentPreviewIndex}";
            LblCurrentSnapshotPreview.Text = $"{previewName} {Environment.NewLine} NOTE: Frames may be blurry due to key frames; will not be blurry on export.";
            PbVideoPreview.ImageLocation = Path.Combine(_creator.PREVIEW_DIRECTORY, $"{previewName}.png");
        }

        /// <summary>
        /// Updates the ContactSheet Picturebox, called after a successful run or when the user clicks 'Next'
        /// </summary>
        private void UpdateContactSheetPictureBox()
        {
            if (_creator == null)
            {
                MessageBox.Show("MediaCreator is null, something catastrophic has gone wrong.", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PbContactSheet.ImageLocation = Path.Combine(_creator.OUTPUT_DIRECTORY, $"final_contact_sheet.png");
        }

        /// <summary>
        /// Updates the Gif Picturebox, called after a successful run.
        /// </summary>
        private void UpdateGifPictureBox()
        {
            if (_creator == null)
            {
                MessageBox.Show("MediaCreator is null, something catastrophic has gone wrong.", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PbGifPreview.ImageLocation = Path.Combine(_creator.OUTPUT_DIRECTORY, $"generated_preview.gif");
        }

        /// <summary>
        /// Deletes all frames and output for the current media before running ContactSheet Generation to ensure no overlaps or duplicates
        /// </summary>
        /// <param name="includePreviews">
        /// Whether or not to delete previews also
        /// </param>
        private void DeleteFilesFromDirectories(bool includePreviews = false)
        {
            if (_creator == null)
            {
                MessageBox.Show("MediaCreator is null, something catastrophic has gone wrong.", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> directories =
            [
                _creator.FRAME_DIRECTORY,
                _creator.OUTPUT_DIRECTORY,
                _creator.ANNOTATED_FRAME_DIRECTORY
            ];

            // if we also want to delete previews
            if (includePreviews)
            {
                directories.Add(_creator.PREVIEW_DIRECTORY);
            }

            // Iterate over each directory
            foreach (string dir in directories)
            {
                try
                {
                    // Check if directory exists
                    if (Directory.Exists(dir))
                    {
                        // Get all files in the directory
                        string[] files = Directory.GetFiles(dir);

                        // Delete each file
                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LazyLogger.Error<FrmMain>($"An error occurred while deleting files in {dir}: {ex.Message}");
                }
            }

        }

        private void ActionRunning(bool isRunning)
        {
            if (isRunning)
            {
                LblGifPleaseWait.Visible = true;
                LblContactSheetPleaseWait.Visible = true;
                LblPreviewPleaseWait.Visible = true;
                tabCtrl.Enabled = false;
            }
            else
            {
                LblGifPleaseWait.Visible = false;
                LblContactSheetPleaseWait.Visible = false;
                LblPreviewPleaseWait.Visible = false;
                tabCtrl.Enabled = true;
            }
        }

        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // prevent the user going to other tabs unless they've clicked start
            if (!_canChangeTabs)
            {
                tabCtrl.SelectedIndex = 0;
                return;
            }
        }

        private void CbCompressContactSheet_CheckedChanged(object sender, EventArgs e)
        {
            if (CbCompressContactSheet.Checked)
            {
                TxtCompressContactSheetResolution.Enabled = true;
                TxtCompressContactSheetResolution.Text = "1280x720";
                return;
            }

            TxtCompressContactSheetResolution.Enabled = false;
            TxtCompressContactSheetResolution.Text = string.Empty;
        }

        private void TxtCompressContactSheetResolution_Leave(object sender, EventArgs e)
        {
            if (TxtCompressContactSheetResolution.ValidateResolution())
            {
                return;
            }

            MessageBox.Show("Not a valid resolution", "Resolution Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TxtCompressContactSheetResolution.Text = string.Empty;
        }

        private void BtnLicenses_Click(object sender, EventArgs e)
        {
            Process.Start(
                new ProcessStartInfo("licenses")
                {
                    UseShellExecute = true
                }
            );
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{AssemblyAttributes.AssemblyCopyright}\r\n{Application.ProductVersion}\r\nhttps://github.com/mckenzie-software/vid2contactsheet", $"About {Text}", MessageBoxButtons.OK);
        }
    }
}
