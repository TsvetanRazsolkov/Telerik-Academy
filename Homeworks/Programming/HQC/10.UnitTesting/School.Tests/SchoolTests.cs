namespace School.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingSchoolWithNullAsNameShouldThrow()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingSchoolWithEmptyNameShouldThrow()
        {
            var school = new School(string.Empty);
        }

        [TestMethod]
        public void CreatingSchoolWithValidNameShouldNotThrow()
        {
            var school = new School("Telerik Academy");
        }

        [TestMethod]
        public void CreatingSchoolShouldCreateEmptyListOfCourses()
        {
            var school = new School("Telerik Academy");

            Assert.AreEqual(0, school.Courses.Count, "Creating school did not create empty list of courses.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullCourseShouldThrow()
        {
            var school = new School("Telerik Academy");

            school.AddCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingExistingCourseShouldThrow()
        {
            var school = new School("Telerik Academy");
            var course = new Course("CSS");

            school.AddCourse(course);
            school.AddCourse(course);            
        }

        [TestMethod]
        public void AddingValidCourseShouldBeDoneCorrectly()
        {
            var school = new School("Telerik Academy");
            var course = new Course("Some course");

            school.AddCourse(course);

            Assert.AreSame(course, school.Courses.First(), "Valid course was not added corectly to school");
        }

        [TestMethod]
        public void AddingValidStudentShouldBeDoneCorrectly()
        {
            var school = new School("Telerik Academy");
            var student = new Student("John Hohn", 10000);

            school.AddStudent(student);

            Assert.AreSame(student, school.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullStudentShouldThrow()
        {
            var school = new School("Telerik Academy");

            school.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingExistingStudentShouldThrow()
        {
            var school = new School("Telerik Academy");
            var student = new Student("John Hohn", 10000);

            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingStudentWithDuplicateIdShouldThrow()
        {
            var school = new School("Telerik Academy");
            var student = new Student("John", 10000);
            var otherStudent = new Student("Hohn", 10000);

            school.AddStudent(student);
            school.AddStudent(otherStudent);
        }
    }
}
