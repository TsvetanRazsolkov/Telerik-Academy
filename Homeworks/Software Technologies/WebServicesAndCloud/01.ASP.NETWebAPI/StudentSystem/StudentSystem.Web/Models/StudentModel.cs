namespace StudentSystem.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using StudentSystem.Models;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromDataToStudentModel
        {
            get
            {
                return s => new StudentModel
                {
                    Address = s.AdditionalInformation.Address,
                    Email = s.AdditionalInformation.Email,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Level = s.Level,
                    StudentIdentification = s.StudentIdentification
                };
            }
        }

        public static Student FromStudentModelToData(StudentModel studentModel)
        {
            return new Student()
            {
                AdditionalInformation = new StudentInfo()
                {
                    Address = studentModel.Address,
                    Email = studentModel.Email
                },
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Level = studentModel.Level,
                StudentIdentification = studentModel.StudentIdentification
            };
        }

        public int StudentIdentification { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Level { get; set; }

        public string Assistant { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}