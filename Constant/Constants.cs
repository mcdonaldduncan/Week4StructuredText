
namespace Week4StructuredText.Constant
{
    public sealed class Constants
    {
        private const string folderName = "temp";

        public static string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        public sealed class FileExtensions
        {
            public static string JSON => ".json";
            public static string XML => ".xml";
            public static string CSV => ".csv";
            public static string Pipe => ".txt";
            public static string Text => ".txt";
        }

        public sealed class FileDelimiters
        {
            public static string JSON => "";
            public static string XML => "";
            public static string CSV => ",";
            public static string Pipe => "|";
            public static string Text => " ";
        }
    }
}
