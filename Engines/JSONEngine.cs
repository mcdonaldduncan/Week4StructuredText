using Newtonsoft.Json;
using Week4StructuredText.Constant;
using Week4StructuredText.Objects;

namespace Week4StructuredText.Engines
{
    internal sealed class JSONEngine : Engine
    {
        /// <summary>
        /// ProcessFiles takes a list of IDeliminated files with JSON extension and processes each of them sequentially
        /// </summary>
        /// <param name="filesToProcess">List of Ideliminated files prepared by the parser and MyFile constructor</param>
        /// <returns errors>List of errors while processing</returns>
        public override List<Error> ProcessFiles(List<IDeliminated> filesToProcess)
        {
            List<Error> errors = new List<Error>();
            try
            {
                foreach (var file in filesToProcess)
                {
                    string writePath = file.FilePath.Replace(file.Extension, $"_out{Constants.FileExtensions.Text}");

                    if (File.Exists(writePath))
                    {
                        File.Delete(writePath);
                    }

                    using (StreamReader sr = new StreamReader(file.FilePath))
                    {
                        // class example
                        Student newStudent = JsonConvert.DeserializeObject<Student>(sr.ReadToEnd());

                        using (StreamWriter sw = new StreamWriter(writePath, true))
                        {
                            sw.WriteLine($"Processed at: {DateTime.Now}");
                            sw.WriteLine();
                            sw.Write(newStudent.ReturnString());
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
