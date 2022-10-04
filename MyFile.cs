using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4StructuredText
{
    internal class MyFile : IDeliminated
    {
        public string Delimiter { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
        public bool LoadError { get; set; }

        /// <summary>
        /// MyFile Constructor handles the creation of valid MyFile objects, and sets the LoadError property to true if the file extension is invalid
        /// </summary>
        /// <param name="fileName">string name for the file</param>
        public MyFile(string fileName, out bool error)
        {
            if (fileName.EndsWith(Constants.FileExtensions.Pipe))
            {
                Delimiter = Constants.FileDelimiters.Pipe;
                Extension = Constants.FileExtensions.Pipe;
                error = false;
            }
            else if (fileName.EndsWith(Constants.FileExtensions.CSV))
            {
                Delimiter = Constants.FileDelimiters.CSV;
                Extension = Constants.FileExtensions.CSV;
                error = false;
            }
            else
            {
                Delimiter = "Invalid";
                Extension = "Invalid";
                error = true;
            }

            FilePath = Path.Combine(Constants.directoryPath, fileName); ;
        }
    }
}
