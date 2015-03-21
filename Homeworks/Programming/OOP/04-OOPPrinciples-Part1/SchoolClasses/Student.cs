namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;


    public class Student : Person
    {
        private int numberInClass;

        public Student(string name, int classNumber) : base(name)
        {
            this.NumberInClass = classNumber;
        }

        public int NumberInClass
        {
            get { return this.numberInClass; }
            private set
            {
                if (value <= 0 )
                {
                    throw new ArgumentException("Class number can not be zero or negative.");
                }
                this.numberInClass = value;
            }
        }

        public override string ToString()
        {
            return "Name: " + this.Name + ", Number in class: " + this.NumberInClass + ", Comment: " + this.Comment;
        }
    }
}
