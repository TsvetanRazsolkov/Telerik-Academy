namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsAndWorkersTest
    {
        private static readonly string separator = new string('-', Console.WindowWidth);

        static void Main()
        {
            List<Human> students = InitializeStudentsList();
            List<Human> workers = InitializeWorkersList();

            Console.WriteLine("  Students sorted by their grade: ");
            var sortedStudents = students.OrderBy(st => (st as Student).Grade)
                                         .ThenBy(st => st.FirstName)
                                         .ThenBy(st => st.LastName);
            Console.WriteLine(string.Join(Environment.NewLine, sortedStudents));
            Console.Write(separator);

            Console.WriteLine("  Workers sorted by money earned per hour: ");
            var sortedWorkers = workers.OrderByDescending(w => (w as Worker).HourWage())
                                       .ThenBy(w => w.FirstName)
                                       .ThenBy(w => w.LastName);
            Console.WriteLine(string.Join(Environment.NewLine, sortedWorkers));
            Console.Write(separator);

            Console.WriteLine("  Students and workers merged in one list, sorted by name: ");
            var sortedHumans = students.Concat(workers) // Could use Union() as well, in this case it doesn't matter;
                                       .OrderBy(h => h.FirstName)
                                       .ThenBy(h => h.LastName);
            foreach (var human in sortedHumans)
            {
                Console.WriteLine("{0} - {1}", human, human.GetType().Name);
            }
            Console.Write(separator);
        }

        private static List<Human> InitializeWorkersList()
        {
            List<Human> workers = new List<Human>();

            workers.Add(new Worker("Bai", "Ivan", 500, 8));
            workers.Add(new Worker("Bai", "Vasil", 400, 8));
            workers.Add(new Worker("Bai", "Gosho", 450, 8));
            workers.Add(new Worker("Bai", "Atanas", 432, 8));
            workers.Add(new Worker("Bai", "Pesho", 504, 10));
            workers.Add(new Worker("Bache", "Kiko", 180, 4));
            workers.Add(new Worker("Bai", "Dobri", 360, 8));
            workers.Add(new Worker("Bai", "Bye", 380, 7));
            workers.Add(new Worker("Bai", "Xoxo", 1200, 8));
            workers.Add(new Worker("Bai", "Xexe", 750, 8));
                                              
            return workers;
        }

        private static List<Human> InitializeStudentsList()
        {
            List<Human> students = new List<Human>();

            students.Add(new Student("Ivancho", "B", 10));
            students.Add(new Student("Mariika", "C", 6));
            students.Add(new Student("Gosho", "E", 4));
            students.Add(new Student("Pesho", "G", 2));
            students.Add(new Student("Silvio", "Berlusconi", 5));
            students.Add(new Student("Angela", "Merkel", 6));
            students.Add(new Student("Mihalaki", "M", 12));
            students.Add(new Student("Haralampi", "O", 3));
            students.Add(new Student("Vladimir", "Putin", 7));
            students.Add(new Student("Dmitrii", "Medvedev", 12));

            return students;
        }
    }
}
