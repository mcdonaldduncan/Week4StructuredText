using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4StructuredText
{
    internal sealed class Constants
    {
        private const string folderName = "temp";

        internal static string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        
        public sealed class FileExtensions
        {
            public static string CSV => ".csv";
            public static string Pipe => ".txt";
            public static string Text => ".txt";
        }

        public sealed class FileDelimiters
        {
            public static string CSV => ",";
            public static string Pipe => "|";
            public static string Text => " ";
        }
    }
}
