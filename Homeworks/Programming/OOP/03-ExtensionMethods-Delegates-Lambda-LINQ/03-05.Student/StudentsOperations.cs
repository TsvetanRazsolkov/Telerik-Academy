namespace Student
{
    using System;
    using System.Linq;

    public class StudentsOperations
    {
        public static readonly string separator = new string('-', Console.WindowWidth);
        static void Main()
        {
            Student[] array = new Student[]{new Student("Asen", "Borisov", 19),
                                            new Student("Boris", "Asenov", 25),
                                            new Student("Gosho" , "Peshov", 20),
                                            new Student("Pesho", "Goshov", 88),
                                            new Student("Pesho", "Peshov", 40)};
           
            Console.WriteLine("Task 3: First before last");
            FirstBeforeLast(array);
            Console.WriteLine(separator);

            Console.WriteLine("Task 4: Age Range");
            AgeRange(array);
            Console.WriteLine(separator);

            Console.WriteLine("Task 5: Order students");
            Console.WriteLine("With lambda: ");
            var sortedArray = array.OrderByDescending(st => st.FirstName)
                                   .ThenByDescending(st => st.LastName);
            Console.WriteLine(string.Join(Environment.NewLine, sortedArray));
            Console.WriteLine("With LINQ: ");
            OrderStudents(array);

        }

        public static void OrderStudents(Student[] array)
        {
            var sortedArray = from student in array
                              orderby student.LastName descending
                              orderby student.FirstName descending
                              select student;
            foreach (var student in sortedArray)
            {
                Console.WriteLine(student);
            }
        }

        public static void AgeRange(Student[] array)
        {
            var names = from student in array
                        where student.Age >= 18 && student.Age <= 24
                        select student.FirstName + " " + student.LastName;
            foreach (var namePair in names)
            {
                Console.WriteLine(namePair);
            }
        }

        public static void FirstBeforeLast(Student[] array)
        {
            var targetStudents = from student in array
                                 where student.FirstName.CompareTo(student.LastName) < 0
                                 select student;
            foreach (var student in targetStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
