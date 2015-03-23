namespace Student
{
    using System;

    public class StudentTest
    {
        public static readonly string separator = new string('-', Console.WindowWidth);

        public static void Main()
        {
            var student = new Student("Pesho", "Petrov", "Peshov", "123-45-6789", "some address",
                                      "some phone", "some eMail", 2,
                                      Universities.TU, Faculties.Mathematics, Specialities.Drinking);
            var otherStudent = new Student("Pesho", "Petrov", "Peshov", "000-11-2222", "some address",
                                      "some phone", "some eMail", 2,
                                      Universities.TU, Faculties.Mathematics, Specialities.Drinking);

            Console.WriteLine("  Two students with same names, universities and all, except SSN:");
            Console.WriteLine("{0}\n -{1}'s hash code = {2}\n", student, student.FirstName, student.GetHashCode());
            Console.WriteLine("{0}\n -{1}'s hash code = {2}\n", otherStudent, otherStudent.FirstName, otherStudent.GetHashCode());
            Console.WriteLine("Are the two students equal? - {0}", student == otherStudent);
            Console.WriteLine("Are the two students different? - {0}", student != otherStudent);
            Console.Write(separator);

            Console.WriteLine("  Two students, one is clone of the other:");
            var clone = (Student)student.Clone();
            clone.Course = 4;
            clone.MobilePhone = "another phone";
            clone.PermanentAddress = "new address";
            Console.WriteLine("Original: {0}", student);
            Console.WriteLine("Clone with changed phone, address and course: {0}", clone);
            Console.WriteLine("The original is not affected by changes made in the clone.");
            Console.Write(separator);

            Student newStudent = new Student("Gosho", "Petrov", "Peshov", "123-45-6789", "some address",
                                      "some phone", "some eMail", 2,
                                      Universities.TU, Faculties.Mathematics, Specialities.Dancing);
            Console.WriteLine("  Comparing two students with same names but different SSNs: ");
            CompareStudents(student, otherStudent);
            Console.WriteLine("  Comparing two students with different names: ");
            CompareStudents(student, newStudent);
            Console.WriteLine("  Comparing two students with same names and SSNs: ");
            CompareStudents(student, clone);
            Console.Write(separator);

        }

        private static void CompareStudents(Student student, Student otherStudent)
        {
            if (student.CompareTo(otherStudent) < 0)
            {
                Console.WriteLine("{0}  IS BIGGER THAN\n{1}", otherStudent, student);
            }
            else if (student.CompareTo(otherStudent) == 0)
            {
                Console.WriteLine("The two students are equal.");
            }
            else
            {
                Console.WriteLine("{0}  IS BIGGER THAN\n{1}", student, otherStudent);
            }
        }
    }
}
