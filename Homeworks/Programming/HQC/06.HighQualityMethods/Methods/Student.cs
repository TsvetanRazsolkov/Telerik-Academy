namespace Methods
{
    using System;

    public class Student
    {
        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string OtherInfo { get; private set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDateOfBirth = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime secondDateOfBirth = DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));
            bool isOlder = firstDateOfBirth < secondDateOfBirth;

            return isOlder;
        }
    }
}
