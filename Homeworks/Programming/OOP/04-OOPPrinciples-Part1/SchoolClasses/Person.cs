namespace SchoolClasses
{
    using System;

    public class Person : IComment
    {
        private string name;
        private string comment = string.Empty;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get { return this.name; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty string.");
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
    }
}
