namespace StudentSystem.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using StudentSystem.Models;

    public class TestModel
    {
        public static Expression<Func<Test, TestModel>> FromDataToTestModel
        {
            get
            {
                return t => new TestModel
                {
                    Course = t.Course.Name
                };
            }
        }

        public static Test FromTestModelToData(TestModel testModel, Course course)
        {
            return new Test()
            {
                Course = course
            };
        }

        [Required]
        public string Course { get; set; }
    }
}