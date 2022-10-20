using System.Xml.Serialization;
using Week4StructuredText.Constant;
using Week4StructuredText.XML_Objects;

namespace Week4StructuredText.Engines
{
    internal sealed class XMLEngine : Engine
    {
        /// <summary>
        /// ProcessFiles takes a list of IDeliminated files with XML extension and processes each of them sequentially
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

                    using (var fs = File.Open(file.FilePath, FileMode.Open))
                    {
                        // class example
                        XmlSerializer serializer = new XmlSerializer(typeof(Market));
                        var marketInventory = (Market?)serializer.Deserialize(fs) ?? new Market();

                        using (StreamWriter sw = new StreamWriter(writePath, true))
                        {
                            sw.WriteLine($"Processed at: {DateTime.Now}");
                            sw.WriteLine();
                            sw.Write(marketInventory.ToString());
                        }
                    }
                }
            }
            catch (IOException ioe)
            {
                errors.Add(new Error(ioe.Message, ioe.Source ?? "Unknown"));
            }
            catch (Exception e)
            {
                errors.Add(new Error(e.Message, e.Source ?? "Unknown"));
            }

            return errors;
        }
    }
}
