namespace SchoolClasses
{
    using System;
    using System.Text;

    public class Discipline : IComment
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExcercises;
        private string comment;

        public Discipline(string name, int numberOfLectures, int numberOfExcercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExcercises = numberOfExcercises;
        }

        public int NumberOfExcercises
        {
            get { return this.numberOfExcercises; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of excercises must be more than zero.");
                }
                this.numberOfExcercises = value;
            }
        }

        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of lectures must be more than zero.");
                }
                this.numberOfLectures = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Discipline name can not be null or empty.");
                }
                this.name = value;
            }
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

        public void ChangeNumberOfExcercises(int numberOfExcercises)
        {
            this.NumberOfExcercises = numberOfExcercises;
        }

        public void ChangeNumberOfLectures(int numberOfLectures)
        {
            this.NumberOfLectures = numberOfLectures;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(this.Name);
            result.AppendLine("Comment: " + this.Comment);
            result.AppendLine("Number of lectures: " + this.NumberOfLectures +
                              ", Number of exercises: " + this.NumberOfExcercises);

            return result.ToString();
        }
    }
}
