using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Week4StructuredText.Objects
{
    internal class Student
    {
        public string FirstName;

        public string LastName;

        public bool IsEnrolled;

        public int YearsEnrolled;

        public Address Address1;

        public Address? Address2;

        public List<PhoneNumber> PhoneNumbers;
    }
}
