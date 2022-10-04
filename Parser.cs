﻿using System;
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
        public Parser()
        {
            Console.WriteLine("Process Started!");

            List<string> fileNames = GetAllFiles();

            foreach (var name in fileNames)
            {
                filesToProcess.Add(new MyFile(name, out bool error));
                if (error)
                {
                    errors.Add(new Error($"Invalid File Extension, {name.Substring(name.LastIndexOf("."))} is not supported", $"{name}"));
                }
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

            errors = Engine.ProcessFiles(filesToProcess);

            if(!hasErrors)
            {
                Console.WriteLine("Process completed succesfully for all items!");
            }
            else
            {
                Console.WriteLine("Process exited with errors!");
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.ErrorMessage} Source: {error.Source}");
                }
            }
        }

        List<string> GetAllFiles()
        {
            return Directory.GetFiles(Constants.directoryPath).Where(x => !x.EndsWith("_out.txt")).ToList();
        }
        
    }
}
