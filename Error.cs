using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Week4StructuredText
{
    internal class Error
    {
        public string ErrorMessage { get; set; }
        public string Source { get; set; }

        public Error(string message, string source)
        {
            ErrorMessage = message;
            Source = source;
        }
    }
}
