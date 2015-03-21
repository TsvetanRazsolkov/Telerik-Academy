namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;

    public class SchoolClassesTest
    {
        public static readonly string separator = new string('-', Console.WindowWidth);

        static void Main()
        {
            List<Class> schoolClasses = FillSchool();
            School someSchool = new School(schoolClasses.ToArray());
            someSchool.AddClass(new Class(GetStudents(), "some class", new Teacher("Chicho Chocho", new Discipline("P.E.", 2, 4))));
            someSchool.Classes[1].AddComment("The best class.");

            string schoolInfo = someSchool.ToString();// Not a nice way to do it, but it fits the exercise;
            Console.WriteLine("School information:\n" + schoolInfo);

            someSchool.Classes[0].DeleteComment();
            Console.WriteLine("School info after deleting the comments about the class with classID Mathematics:");
            Console.WriteLine(someSchool.ToString());
        }
                
        private static List<Class> FillSchool()
        {
            List<Class> classes = new List<Class>();

            Class math = new Class(GetStudents(),
                                   "Mathematics", 
                                   new Teacher("Chicho Mitko", new Discipline("Math", 2, 4), new Discipline("Physics", 2, 4)));
            math.AddStudent(new Student("Pesho", 5));
            math.AddTeacher(new Teacher("Chicho Gosho", new Discipline("Distillery", 4, 6)));
            math.AddComment("Yeah, quite interesting.");
            math.Teachers[1].Disciplines[0].AddComment("Beer.");

            classes.Add(math);

            Class philosophy = new Class(GetStudents(),
                                   "Phylosophy",
                                   new Teacher("Chicho Pencho", new Discipline("Math", 2, 4), new Discipline("Physics", 2, 4)),
                                   new Teacher("Chicho Gencho",new Discipline("Philosophy", 3, 5)));
            philosophy.Teachers[1].AddDiscipline(new Discipline("Transcendental metascience", 2, 1));
            philosophy.Teachers[0].AddComment("Everybody likes him.");

            classes.Add(philosophy);

            return classes;
        }


        private static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Ivancho", 1),
                new Student("Mariika", 2),
                new Student("Kirkor", 3),
                new Student("Garabed", 4)
            };

            students[0].AddComment("Prosperous student.");

            return students;
        }
    }
}
