using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4StructuredText.Constant;
using Week4StructuredText.Objects;
using Week4StructuredText.Parsing;

namespace Week4StructuredText.Engines
{
    internal class JSONEngine : Engine
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

                    using (StreamReader sr = new StreamReader(file.FilePath))
                    {
                        Student newStudent = JsonConvert.DeserializeObject<Student>(sr.ReadToEnd());

                        using (StreamWriter sw = new StreamWriter(writePath, true))
                        {
                            sw.WriteLine($"Processed at: {DateTime.Now}");
                            sw.WriteLine();

                            sw.WriteLine($"Name: {newStudent.LastName}, {newStudent.FirstName}");
                            sw.WriteLine(newStudent.IsEnrolled ? "Student is currently enrolled." : "Student is not enrolled");
                            sw.WriteLine($"Student enrolled for {newStudent.YearsEnrolled} years.");
                            sw.WriteLine($"Primary Adress: {newStudent.Address1.ReturnString()}");
                            sw.WriteLine(newStudent.Address2 == null ? "No secondary address" : $"Secondary Adress: {newStudent.Address2.ReturnString()}");
                            for (int i = 0; i < newStudent.PhoneNumbers.Count; i++)
                            {
                                sw.WriteLine($"Phone Number {i + 1}: {newStudent.PhoneNumbers[i].Number} | {newStudent.PhoneNumbers[i].Type} | Can Contact: {(newStudent.PhoneNumbers[i].CanContact ? "Yes" : "No")}");
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
