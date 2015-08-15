namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private string name;
        private ICollection<Course> courses;
        private ICollection<Student> students;

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfNullOrEmptyString(value, "School name");
                this.name = value;
            }
        }

        public ICollection<Course> Courses
        {
            get { return new List<Course>(this.courses); }
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddCourse(Course courseToAdd)
        {
            Validator.CheckIfNull(courseToAdd, "Course to add to school");

            if (this.Courses.Contains(courseToAdd))
            {
                throw new InvalidOperationException("Cannot add course, school already has it.");
            }

            this.courses.Add(courseToAdd);
        }

        public void AddStudent(Student student)
        {
            Validator.CheckIfNull(student, "Student to add to school");

            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException("Cannot add student - it's already added.");
            }

            if (this.Students.Any(st => st.UniqueStudentNumber == student.UniqueStudentNumber))
            {
                throw new ArgumentException("There is already a student with the same ID.");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.CheckIfNull(student, "Student to remove from school");

            if (!this.Students.Contains(student))
            {
                throw new InvalidOperationException("No such student to remove.");
            }

            this.students.Remove(student);
        }
    }
}
