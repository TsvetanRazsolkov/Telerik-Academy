namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private ICollection<string> students;

        public Course(string courseName, string teacherName, ICollection<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.students = new List<string>(students);
        }

        public Course(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidateIfStringIsNullOrEmpty(value, "Course name");
                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            private set
            {
                Validator.ValidateIfStringIsNullOrEmpty(value, "Teacher name");
                this.teacherName = value;
            }
        }

        public ICollection<string> Students
        {
            get
            {
                return new List<string>(this.students);
            }
        }

        public void ChangeTeacher(string newTeacherName)
        {
            this.TeacherName = newTeacherName;
        }

        public void AddStudents(params string[] students)
        {
            Validator.ValidateIfNull(students, "Students collection");

            foreach (var studentName in students)
            {
                Validator.ValidateIfStringIsNullOrEmpty(studentName, "Student name");
                this.students.Add(studentName);
            }
        }

        public void AddStudents(IEnumerable<string> students)
        {
            Validator.ValidateIfNull(students, "Students collection");

            foreach (var studentName in students)
            {
                Validator.ValidateIfStringIsNullOrEmpty(studentName, "Student name");
                this.students.Add(studentName);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} {{ Name = ", this.GetType().Name);
            result.Append(this.Name);

            result.Append("; Teacher = ");
            result.Append(this.TeacherName);

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
