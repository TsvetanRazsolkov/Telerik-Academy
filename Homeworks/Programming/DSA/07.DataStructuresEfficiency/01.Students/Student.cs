namespace _01.Students
{
    using System;

    public class Student : IComparable<Student>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        public int CompareTo(Student other)
        {
            return this.LastName.CompareTo(other.LastName) != 0 ? this.LastName.CompareTo(other.LastName)
                                                                : this.FirstName.CompareTo(other.FirstName);
        }
    }
}
