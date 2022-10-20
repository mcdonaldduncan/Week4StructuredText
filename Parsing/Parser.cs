using System.Collections.Generic;
using System.Xml.Linq;
using Week4StructuredText.Constant;
using Week4StructuredText.Engines;
using static Week4StructuredText.Constant.Constants;

namespace Week4StructuredText.Parsing
{
    internal sealed class Parser
    {
        List<IDeliminated> filesToProcess = new List<IDeliminated>();
        List<Error> errors = new List<Error>();

        bool hasErrors => errors.Any();

        /// <summary>
        /// Parser Constructor takes a list of strings, converts them into MyFile objects, and adds them to the filesToProcess list 
        /// before initiating the engine process, parser uses MyFile constructor to check for file extension errors
        /// </summary>
        /// <param name="fileNames">string names of the files that the user wants to parse</param>
        public Parser()
        {
            Console.WriteLine("Process Started!");

            List<string> fileNames = GetAllFiles();

            foreach (var name in fileNames)
            {
                filesToProcess.Add(CreateFile(name));
            }

            if (hasErrors)
            {
                Console.WriteLine("Process exited with errors.");
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.ErrorMessage} Source: {error.Source}");
                }
                return;
            }

            Engine engine;

            engine = new DelimiterEngine();
            errors.AddRange(engine.ProcessFiles(filesToProcess.Where(x => x.Extension == FileDelimiters.Pipe || x.Extension == FileDelimiters.CSV).ToList()));

            engine = new JSONEngine();
            errors.AddRange(engine.ProcessFiles(filesToProcess.Where(x => x.Extension == FileExtensions.JSON).ToList()));

            engine = new XMLEngine();
            errors.AddRange(engine.ProcessFiles(filesToProcess.Where(x => x.Extension == FileExtensions.XML).ToList()));

            if (hasErrors)
            {
                Console.WriteLine("Process exited with errors!");
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.ErrorMessage} Source: {error.Source}");
                }
            }
            else
            {
                Console.WriteLine("Process completed succesfully for all items!");
            }
        }

        List<string> GetAllFiles()
        {
            return Directory.GetFiles(directoryPath).Where(x => !x.EndsWith("_out.txt")).ToList();
        }

        /// <summary>
        /// CreateFiles handles the creation of valid MyFile objects, adds an error if one is found
        /// This could definitely be a MyFile constructor and it was at one point, moved it here to keep this logic in the same place
        /// </summary>
        /// <param name="fileName">string name for the file</param>
        MyFile CreateFile(string fileName)
        {
            MyFile file = new MyFile();
            if (fileName.EndsWith(FileExtensions.Pipe))
            {
                file.Delimiter = FileDelimiters.Pipe;
                file.Extension = FileExtensions.Pipe;
            }
            else if (fileName.EndsWith(FileExtensions.CSV))
            {
                file.Delimiter = FileDelimiters.CSV;
                file.Extension = FileExtensions.CSV;
            }
            else if (fileName.EndsWith(FileExtensions.JSON))
            {
                file.Delimiter = FileDelimiters.JSON;
                file.Extension = FileExtensions.JSON;
            }
            else if (fileName.EndsWith(FileExtensions.XML))
            {
                file.Delimiter = FileDelimiters.XML;
                file.Extension = FileExtensions.XML;
            }
            else
            {
                errors.Add(new Error($"Invalid File Extension, {fileName.Substring(fileName.LastIndexOf("."))} is not supported", $"{fileName}"));
            }
            file.FilePath = Path.Combine(directoryPath, fileName);

            return file;
        }
    }
}
