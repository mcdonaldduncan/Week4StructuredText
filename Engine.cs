using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4StructuredText
{
    internal class Engine
    {
        static List<Error> errors = new List<Error>();
        static bool hasErrors => errors.Any();
        
        /// <summary>
        /// ProcessFiles takes a list of IDeliminated files and processes each of them sequentially
        /// </summary>
        /// <param name="filesToProcess">List of Ideliminated files prepared by the parser and MyFile constructors</param>
        public static void ProcessFiles(List<IDeliminated> filesToProcess)
        {
            for (int i = 0; i < filesToProcess.Count; i++)
            {
                Dictionary<int, string[]> lines = new Dictionary<int, string[]>(0);
                string writePath = filesToProcess[i].FilePath.Replace(filesToProcess[i].Extension, $"_out.txt");
                List<string> temp = new List<string>();
                int lineIndex = 1;

                if (File.Exists(writePath))
                {
                    File.Delete(writePath);
                }

                using (StreamReader sr = new StreamReader(filesToProcess[i].FilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        var lineItems = line.Split(filesToProcess[i].Delimiter);
                        lines.Add((lineIndex++), lineItems);
                    }
                }

                if (hasErrors)
                {
                    Console.WriteLine("Process exited with errors!");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage} in {error.Source}");
                    }
                    return;
                }

                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine($"File Processed at: {DateTime.Now}");
                    sw.WriteLine();
                    
                    foreach (var item in lines)
                    {
                        sw.Write($"Line#{item.Key}: ");
                        for (int j = 0; j < item.Value.Length; j++)
                        {
                            sw.Write($"Field#{j + 1}={item.Value[j]}");
                            if (!(j + 1 == item.Value.Length))
                            {
                                sw.Write(" ==> ");
                            }
                        }
                        sw.WriteLine();
                        sw.WriteLine();
                    }
                }
            }
            
            if (!hasErrors)
            {
                Console.WriteLine("Process completed succesfully for all items!");
            }
        }
    }
}
