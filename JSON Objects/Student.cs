
using Week4StructuredText.Printing;

namespace Week4StructuredText.Objects
{
    internal sealed class Student : Printable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsEnrolled { get; set; }

        public int YearsEnrolled { get; set; }

        public Address Address1 { get; set; }

        public Address? Address2 { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; }

        public override string ReturnString()
        {
            sb.Append($"Name: {LastName}, {FirstName}\n");
            sb.Append(IsEnrolled ? "Student is currently enrolled.\n" : "Student is not enrolled.\n");
            sb.Append($"Student enrolled for {YearsEnrolled} years\n");
            sb.Append($"Primary Address: {Address1.ReturnString()}\n");
            sb.Append($"Secondary Address: {(Address2 == null ? "No secondary address\n" : $"Secondary Adress: {Address2.ReturnString()}\n")}");
            for (int i = 0; i < PhoneNumbers.Count; i++)
            {
                sb.Append($"Phone Number {i + 1}: {PhoneNumbers[i].ReturnString()}");
            }
            return sb.ToString();
        }
    }
}
