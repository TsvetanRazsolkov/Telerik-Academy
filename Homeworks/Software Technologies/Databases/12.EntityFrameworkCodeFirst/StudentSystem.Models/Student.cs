namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.Id = Guid.NewGuid();
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
            this.ContactInformation = new StudentContactInformation();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Index(IsUnique = true)]
        [Range(100000, 999999)]
        public int Number { get; set; }

        public GenderType Gender { get; set; }

        public StudentContactInformation ContactInformation { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        [NotMapped]
        public bool IsLazy
        {
            get
            {
                return this.Courses.Count < 2;
            }
        }
    }
}
