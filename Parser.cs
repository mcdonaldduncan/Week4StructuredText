using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4StructuredText
{
    internal class Parser
    {
        List<IDeliminated> filesToProcess = new List<IDeliminated>();
        List<Error> errors = new List<Error>();

        bool hasErrors => errors.Any();

        /// <summary>
        /// Parser Constructor takes a list of strings, converts them into MyFile objects, and adds them to the filesToProcess list 
        /// before initiating the engine process, parser uses MyFile constructor to check for file extension errors
        /// </summary>
        /// <param name="fileNames">string names of the files that the user wants to parse</param>
        public Parser(List<string> fileNames)
        {
            foreach (var name in fileNames)
            {
                filesToProcess.Add(new MyFile(name));
            }
            
            foreach (var file in filesToProcess)
            {
                if (file.LoadError)
                {
                    errors.Add(new Error($"File {file.FilePath} has an invalid file extension.", "MyFile() constructor"));
                }
            }

            if (hasErrors)
            {
                Console.WriteLine("Process Exiting due to errors.");
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.ErrorMessage} in {error.Source}");
                }
                return;
            }

            Engine.ProcessFiles(filesToProcess);
        }
        
    }
}
