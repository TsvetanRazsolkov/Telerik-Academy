namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Class : IComment
    {
        private string comment;
        private List<Teacher> teachers;
        private List<Student> students;
        private string classIdentifier;

        public Class(List<Student> students, string classID, params Teacher[] teachers)
        {
            this.students = new List<Student>(students);
            this.teachers = new List<Teacher>(teachers);
            this.ClassIdentifier = classID;
        }

        public string ClassIdentifier
        {
            get { return this.classIdentifier; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Class identifier should not be null or empty string.");
                }
                this.classIdentifier = value;
            }
        }

        public List<Student> Students
        {
            get { return new List<Student>(this.students); }
        }

        public List<Teacher> Teachers
        {
            get { return new List<Teacher>(this.teachers); }
        }

        public string Comment
        {
            get { return this.comment; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.comment = string.Empty;
                }
                this.comment = value;
            }
        }

        public void AddComment(string comment)
        {
            this.Comment = comment;
        }

        public void DeleteComment()
        {
            this.Comment = string.Empty;
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Class: " + ClassIdentifier);
            result.AppendLine("Comments: " + this.Comment);
            result.AppendLine("Students attending: ");
            result.AppendLine(string.Join(Environment.NewLine, this.Students));
            result.AppendLine("Teachers: ");
            result.AppendLine(string.Join(Environment.NewLine, this.Teachers));
            result.Append(SchoolClassesTest.separator);
            
           return result.ToString();
        }
    }
}
