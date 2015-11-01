namespace StudentSystem.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using StudentSystem.Models;

    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromDataToCourseModel
        {
            get
            {
                return c => new CourseModel
                {
                    Description = c.Description,
                    Name = c.Name
                };
            }
        }

        public static Course FromCourseModelToData(CourseModel courseModel)
        {
            return new Course()
            {
                Name = courseModel.Name,
                Description = courseModel.Description
            };
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}