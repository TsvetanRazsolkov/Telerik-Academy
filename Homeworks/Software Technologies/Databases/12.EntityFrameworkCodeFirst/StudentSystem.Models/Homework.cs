namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public Guid? StudentId { get; set; }

        public int CourseId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}
