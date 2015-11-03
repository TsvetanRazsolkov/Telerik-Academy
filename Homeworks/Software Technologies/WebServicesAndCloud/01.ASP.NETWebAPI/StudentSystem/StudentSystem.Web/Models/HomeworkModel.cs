namespace StudentSystem.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using StudentSystem.Models;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromDataToHomeworkModel
        {
            get
            {
                return h => new HomeworkModel
                {
                    Course = h.Course.Name,
                    TimeSent = h.TimeSent,
                    StudentId = h.StudentIdentification
                };
            }
        }

        [Required]
        public string Course { get; set; }

        public int StudentId { get; set; }

        public DateTime TimeSent { get; set; }
    }
}