namespace School.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingCourseWithNullAsNameShouldThrow()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingCourseWithEmptyNameShouldThrow()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        public void CreatingCourseWithValidNameShouldNotThrow()
        {
            var course = new Course("Some course");
        }

        [TestMethod]
        public void CreatingCourseShouldCreateEmptyListOfStudents()
        {
            var course = new Course("Some course");

            Assert.AreEqual(0, course.Students.Count, "Creating course did not create empty list of students.");
        }

        [TestMethod]
        public void AddingValidStudentShouldBeDoneCorrectly()
        {
            var course = new Course("Some course");
            var student = new Student("John", 20000);

            course.AddStudent(student);

            Assert.AreSame(student, course.Students.First(), "Valid student was not added corectly to course");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullStudentShouldThrow()
        {
            var course = new Course("Some course");

            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingExistingStudentShouldThrow()
        {
            var course = new Course("Some course");
            var student = new Student("John Hohn", 10000);

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingStudentAfterMaximumNumberOfStudentsIsReachedShouldThrow()
        {
            var course = new Course("Some course");

            for (int i = 0; i < 40; i++)
            {
                course.AddStudent(new Student("John Hohn", 10000 + i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingStudentWithDuplicateIdShouldThrow()
        {
            var course = new Course("New course");
            var student = new Student("John", 10000);
            var otherStudent = new Student("Hohn", 10000);

            course.AddStudent(student);
            course.AddStudent(otherStudent);
        }

        [TestMethod]
        public void RemoveStudentExpectedToWorkCorrectly()
        {
            var course = new Course("Some course");
            var student = new Student("John", 30000);
            var anotherStudent = new Student("Hohn", 30001);

            course.AddStudent(student);
            course.AddStudent(anotherStudent);
            course.RemoveStudent(student);

            Assert.IsTrue(!course.Students.Contains(student), "Student was not removed correctly from course.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemovingNullStudentShouldThrow()
        {
            var course = new Course("Some course");

            course.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemovingNonExistingStudentShouldThrow()
        {
            var course = new Course("Some course");
            var student = new Student("John Hohn", 10000);

            course.RemoveStudent(student);
        }
    }
}
