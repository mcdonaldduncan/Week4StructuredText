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
        public static List<Error> ProcessFiles(List<IDeliminated> filesToProcess)
        {
            try
            {
                for (int i = 0; i < filesToProcess.Count; i++)
                {
                    Dictionary<int, string[]> lines = new Dictionary<int, string[]>();
                    string writePath = filesToProcess[i].FilePath.Replace(filesToProcess[i].Extension, $"_out{Constants.FileExtensions.Text}");

                    if (File.Exists(writePath))
                    {
                        File.Delete(writePath);
                    }

                    using (StreamReader sr = new StreamReader(filesToProcess[i].FilePath))
                    {
                        int lineIndex = 1;
                        while (!sr.EndOfStream)
                        {
                            var lineItems = sr.ReadLine()?.Split(filesToProcess[i].Delimiter) ?? new string[0];
                            lines.Add((lineIndex++), lineItems);
                        }
                    }

                    using (StreamWriter sw = new StreamWriter(writePath, true))
                    {
                        sw.WriteLine($"Processed at: {DateTime.Now}");
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
            }
            catch (IOException ioe)
            {
                errors.Add(new Error(ioe.Message, ioe.Source));
            }
            catch (Exception e)
            {
                errors.Add(new Error(e.Message, e.Source));
            }

            return errors;
        }
    }
}
