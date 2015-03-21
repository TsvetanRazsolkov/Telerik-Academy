namespace StudentsAndWorkers
{
    using System;

    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade) 
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get { return this.grade; }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Student's grade must be between 1 and 12.");
                }
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, Grade: {2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}
