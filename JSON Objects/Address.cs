using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Week4StructuredText.Objects
{
    internal class Address
    {
        public string StreetAddress;

        public string City;

        public string State;

        public string PostalCode;

        public string ReturnString()
        {
            return $"Primary Adress: {StreetAddress}, {City}, {State}, {PostalCode}";
        }
    }
}
