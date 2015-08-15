namespace School
{
    using System;

    public class Student
    {
        private const int MinValueOfStudentNumber = 10000;
        private const int MaxValueOfStudentNumber = 99999;

        private string name;
        private int uniqueStudentNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueStudentNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfNullOrEmptyString(value, "Student name");

                this.name = value;
            }
        }

        public int UniqueStudentNumber
        {
            get
            {
                return this.uniqueStudentNumber;
            }

            private set
            {
                Validator.CheckIfIntegerInRange(value, MinValueOfStudentNumber, MaxValueOfStudentNumber, "Student unique number");
                
                this.uniqueStudentNumber = value;
            }
        }

        public void JoinCourse(Course course)
        {
            Validator.CheckIfNull(course, "Course to join");

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            Validator.CheckIfNull(course, "Course to leave");

            course.RemoveStudent(this);
        }
    }
}
