namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CreatingValidStudentShouldNotThrowAnException()
        {
            var student = new Student("John Hohn", 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingStudentWithNullAsNameShouldThrow()
        {
            var student = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingStudentWithEmptyNameShouldThrow()
        {
            var student = new Student(string.Empty, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreatingStudentWithInvalidId_Low_ShouldThrow()
        {
            var student = new Student("John Hohn", 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreatingStudentWithInvalidId_High_ShouldThrow()
        {
            var student = new Student("John Hohn", 1000000);
        }

        [TestMethod]
        public void StudentJoiningValidCourseShouldNotThrow()
        {
            var student = new Student("John Hohn", 10000);
            var course = new Course("CSS");

            student.JoinCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentJoiningNullCourseShouldThrow()
        {
            var student = new Student("John Hohn", 10000);

            student.JoinCourse(null);
        }

        [TestMethod]
        public void StudentLeavingValidCourseShouldNotThrow()
        {
            var student = new Student("John Hohn", 10000);
            var course = new Course("CSS");

            student.JoinCourse(course);
            student.LeaveCourse(course);
        }        

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentLeavingNullCourseShouldThrow()
        {
            var student = new Student("John Hohn", 10000);

            student.LeaveCourse(null);
        }
    }
}
