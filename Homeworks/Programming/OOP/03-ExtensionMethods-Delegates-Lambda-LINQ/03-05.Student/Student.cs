namespace Student
{
    using System;

    public class Student
    {
        private int age;

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string  FirstName { get; set; }

        public string LastName { get; set; }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be negative or zero.");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}", this.FirstName, this.LastName, this.Age);
        }
    }
}
