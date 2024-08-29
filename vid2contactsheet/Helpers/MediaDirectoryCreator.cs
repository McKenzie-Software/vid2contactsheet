namespace vid2contactsheet.Helpers
{
    public class MediaDirectoryCreator
    {

        internal static string _rootDirectory = string.Empty;

        public string FRAME_DIRECTORY = string.Empty;
        public string ANNOTATED_FRAME_DIRECTORY = string.Empty;
        public string PREVIEW_DIRECTORY = string.Empty;
        public string OUTPUT_DIRECTORY = string.Empty;

        public MediaDirectoryCreator(string rootDirectory)
        {
            if(string.IsNullOrEmpty(rootDirectory))
            {
                throw new ArgumentNullException(rootDirectory);
            }

            _rootDirectory = rootDirectory;

            FRAME_DIRECTORY = Path.Combine(_rootDirectory, "frames");
            ANNOTATED_FRAME_DIRECTORY = Path.Combine(_rootDirectory, "annotated_frames");
            PREVIEW_DIRECTORY = Path.Combine(_rootDirectory, "previews");
            OUTPUT_DIRECTORY = Path.Combine(_rootDirectory, "output");
        }

        public void CreateStructure()
        {
            if(Directory.Exists(_rootDirectory))
            {
                Directory.Delete(_rootDirectory, true);
            }

            // Create the root directory for the specific file
            // Example C:\Users\laim\AppData\Local\Temp\vid2contactsheet\VID_28032024\
            Directory.CreateDirectory(_rootDirectory);

            // Create the thumbnail directory for file preview
            // Example C:\Users\laim\AppData\Local\Temp\vid2contactsheet\VID_28032024\previews\
            Directory.CreateDirectory(PREVIEW_DIRECTORY);

            // Create the frame directory for video frames pre-annotation
            // Example C:\Users\laim\AppData\Local\Temp\vid2contactsheet\VID_28032024\frames\
            Directory.CreateDirectory(FRAME_DIRECTORY);

            // Create the frame directory for video frames post-annotation
            // Example C:\Users\laim\AppData\Local\Temp\vid2contactsheet\VID_28032024\annotated_frames\
            Directory.CreateDirectory(ANNOTATED_FRAME_DIRECTORY);

            // Create the ouput directory for the file
            // Example CC:\Users\laim\AppData\Local\Temp\vid2contactsheet\VID_28032024\output\
            Directory.CreateDirectory(OUTPUT_DIRECTORY);
        }
    }
}
