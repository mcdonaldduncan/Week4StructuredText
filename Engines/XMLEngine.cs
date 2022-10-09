using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Week4StructuredText.Constant;
using Week4StructuredText.Objects;
using Week4StructuredText.Parsing;
using Week4StructuredText.XML_Objects;

namespace Week4StructuredText.Engines
{
    internal class XMLEngine : Engine
    {
        List<Error> errors = new List<Error>();
        bool hasErrors => errors.Any();

        public override List<Error> ProcessFiles(List<IDeliminated> filesToProcess)
        {
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
                        XmlSerializer serializer = new XmlSerializer(typeof(Market));
                        var marketInventory = (Market)serializer?.Deserialize(fs);

                        using (StreamWriter sw = new StreamWriter(writePath, true))
                        {
                            sw.WriteLine($"Processed at: {DateTime.Now}");
                            sw.WriteLine();
                            for (int i = 0; i < marketInventory.Items.Count; i++)
                            {
                                sw.WriteLine($"Item#{i + 1}: {marketInventory.Items[i].Name} ==> {marketInventory.Items[i].Price}/{marketInventory.Items[i].UnitOfMeasurement}");
                            }
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
