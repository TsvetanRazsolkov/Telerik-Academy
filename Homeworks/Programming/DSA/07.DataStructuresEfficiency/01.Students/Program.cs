
/*A text file students.txt holds information about students and their courses in the following format:
Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the students ordered by family and then by name:
Kiril  | Ivanov   | C#
Stefka | Nikolova | SQL
Stela  | Mineva   | Java
Milena | Petrova  | C#
Ivan   | Grigorov | C#
Ivan   | Kolev    | SQL
C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
Java: Stela Mineva
SQL: Ivan Kolev, Stefka Nikolova*/
namespace _01.Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var reader = new StreamReader("..\\..\\students.txt");
            var orderedStudents = new SortedDictionary<string, SortedSet<Student>>();

            string input = reader.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                string[] studentInfo = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(x => x.Trim()).ToArray();

                string subject = studentInfo[2];
                var student = new Student 
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1]
                };

                if (!orderedStudents.ContainsKey(subject))
                {
                    orderedStudents.Add(subject, new SortedSet<Student>());
                }

                orderedStudents[subject].Add(student);
                input = reader.ReadLine();
            }

            foreach (var course in orderedStudents)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
            }
        }
    }
}
