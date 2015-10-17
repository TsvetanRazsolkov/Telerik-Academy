namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data;
    using Data.Migrations;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());


            using (var db = new StudentSystemDbContext())
            {
                var student = new Student
                {
                    Name = "Random Pesho",
                    Gender = GenderType.Male,
                    Number = 123456
                    // the following will throw the nasty validation exception :)
                    //Number = 123
                };

                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    Console.WriteLine(ex.InnerException.InnerException.Message);

                    Console.WriteLine("This was caused because student number has Unique key constraint set on it and you tried to add the same student twice :P");
                }

                Console.WriteLine("Number of students in students table: {0}", db.Students.Count());

                var lazyStudents = db.Students.ToList()
                                              .Where(s => s.IsLazy)
                                              .Select(s => s.Name);

                Console.WriteLine("Lazy students -> {0}", string.Join(", ", lazyStudents));
            }
        }
    }
}
