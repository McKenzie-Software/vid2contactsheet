using Laim.LazyLogger;

namespace vid2contactsheet.DownloadClient
{
    public class Downloader
    {
        public Downloader()
        {
            if(!Directory.Exists("bin"))
            {
                LazyLogger.Information<Downloader>("./bin does not exist, creating.");
                Directory.CreateDirectory("bin");
            }
        }

        /// <summary>
        /// Downloads the package and writes it to the temp directory using <see cref="Path.GetTempPath"/>
        /// </summary>
        /// <param name="url">
        /// Item to download, must be a .zip
        /// </param>
        /// <returns>
        /// <see cref="Task"/>
        /// </returns>
        public async Task DownloadPackage(string url, string package, IProgress<int> progress)
        {
            if (!await ConnectionTest(url))
            {
                LazyLogger.Fatal<Downloader>($"Unable to connect to {url}");
                return;
            }

            string tempPath = Path.Combine(Path.GetTempPath(), $"{package}.zip");

            try
            {
                using (var client = new HttpClient())
                {
                    // Use GetAsync with HttpCompletionOption.ResponseHeadersRead to enable progress tracking
                    using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        // Get total length of the content to calculate progress
                        long? totalBytes = response.Content.Headers.ContentLength;

                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            // Open file stream with FileMode.Create to write downloaded content
                            using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                            {
                                const int bufferSize = 8192;
                                var buffer = new byte[bufferSize];
                                var bytesRead = 0;
                                var totalBytesRead = 0L;

                                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                                {
                                    await fileStream.WriteAsync(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    // Report progress as a percentage of total file size
                                    if (totalBytes.HasValue)
                                    {
                                        int percentComplete = (int)((float)totalBytesRead / totalBytes.Value * 100);
                                        progress.Report(percentComplete);
                                    }
                                }
                            }
                        }
                    }
                }

                // unzip that bad boi
                LazyLogger.Information<Downloader>($"Extracting {package} to ./bin");
                System.IO.Compression.ZipFile.ExtractToDirectory(tempPath, "bin");

                LazyLogger.Information<Downloader>($"Deleting temporary {package} zip file");
                File.Delete(tempPath);
            }
            catch (Exception ex)
            {
                LazyLogger.Fatal<Downloader>($"{ex}");
            }
        }


        /// <summary>
        /// Checks if there is a successfull connection to the choosen url.
        /// </summary>
        /// <param name="url">
        /// URL to test connection
        /// </param>
        /// <returns>
        /// <see langword="true"/> if successful, else <see langword="false"/>
        /// </returns>
        internal async Task<bool> ConnectionTest(string url)
        {
            HttpClient client = new();
            HttpResponseMessage responseMsg;

            try
            {
                responseMsg = await client.GetAsync(url).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                LazyLogger.Fatal<Downloader>($"{ex}");
                return false;
            }

            if (responseMsg.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
