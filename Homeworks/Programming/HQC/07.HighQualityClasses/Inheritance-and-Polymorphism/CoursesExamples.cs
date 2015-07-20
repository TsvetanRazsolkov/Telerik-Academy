namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases", "Toni Storaro", "Ultimate");
            Console.WriteLine(localCourse);

            localCourse.ChangeLab("Enterprise");
            Console.WriteLine(localCourse);

            localCourse.AddStudents(null);
            Console.WriteLine(localCourse);

            localCourse.ChangeTeacher("Svetlin Nakov");
            localCourse.AddStudents("Milena");
            localCourse.AddStudents("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                "Mario Peshev", 
                new List<string>() { "Thomas", "Ani", "Steve" },
                "Karnobat");
            Console.WriteLine(offsiteCourse);
        }
    }
}
