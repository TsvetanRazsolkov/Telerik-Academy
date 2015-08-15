namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        private const int MaxStudentsInCourse = 29;

        private string name;
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            { 
                return this.name;
            }

            set
            {
                Validator.CheckIfNullOrEmptyString(value, "Course name");
                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get { return new List<Student>(this.students); }
        }

        public void AddStudent(Student student)
        {
            Validator.CheckIfNull(student, "Student to add to course");

            if (this.Students.Count >= MaxStudentsInCourse)
            {
                throw new InvalidOperationException("Course is full. Cannot add more than 29 students");
            }

            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException("Cannot add student - already signed to this course.");
            }

            if (this.Students.Any(st => st.UniqueStudentNumber == student.UniqueStudentNumber))
            {
                throw new ArgumentException("Cannot add student - student with such ID already is added to this course.");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.CheckIfNull(student, "Student to remove from course");

            if (!this.Students.Contains(student))
            {
                throw new InvalidOperationException("Cannot remove student that does not attend course.");
            }
            else
            {
                this.students.Remove(student);
            }
        }
    }
}
