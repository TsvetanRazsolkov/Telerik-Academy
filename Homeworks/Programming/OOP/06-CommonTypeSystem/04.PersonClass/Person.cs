namespace PersonClass
{
    using System;

    public class Person
    {
        private string name;
        private int? age;

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty string.");
                }
                this.name = value;
            }
        }

        public int? Age
        {
            get { return this.age; }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentException("Invalid age.");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}{1}Age: {2}", this.Name, Environment.NewLine,
                                 this.Age == null ? "Not specified." : this.Age.ToString());
        }
    }
}
