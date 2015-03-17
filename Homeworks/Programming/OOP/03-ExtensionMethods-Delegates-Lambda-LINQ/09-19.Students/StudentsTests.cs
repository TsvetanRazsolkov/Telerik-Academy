namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsTests
    {
        public static readonly string separator = new string('-', Console.WindowWidth);

        static void Main()
        {
            List<Student> list = new List<Student>() {
                new Student("Aaaaa","Bbbbb","124506","02123456","bla@abv.bg", 2, new int[]{2, 2, 3, 5}),
                new Student("Bbbbbbb","Aaaaa","124509","+359888888888","ahmak@gmail.com", 1, new int[]{4, 3, 6, 5, 6}),
                new Student("Gosho","Goshov","245106","07788778878","tintiri@abv.bg", 2, new int[]{2, 2, 3, 5}),
                new Student("Pesho","Peshov","123456","089999999","alabala@mail.bg", 3, new int[]{3, 3, 3, 3}),
                new Student("Doko","Doko","156606","00899989855","mintiri@abv.bg", 4, new int[]{6, 6, 6, 5, 4}),
                new Student("Berbati","Dimitrov","654606","+3592777777","monaco@yahoo.com", 3, new int[]{2, 3, 4, 5, 6})};
            //Creating some groups linked to certain departments:
            List<Group> allGroups = new List<Group>() { new Group(3, "Mathematics"),
                                                        new Group(2, "Physics"),
                                                        new Group (1, "Music")};
            Task9(list);// Using LINQ query;
            Task10(list);// The above using LINQ extension methods;
            Task11(list);// Students with email address at abv.bg;
            Task12(list);// Students with phone numbers with Sofia's area code 02;
            Task13(list);// Students who have at least one mark '6';
            Task14(list);//Students with two marks '2';
            Task15(list);//Marks of all students that enrolled in 2006;
            Task16(list, allGroups);//Extracting students who study at department Mathematics;
            Task18(list);//All students grouped by group number;
            Task19(list);//The above using LINQ extension methods;
        }

        private static void Task19(List<Student> list)
        {
            Console.WriteLine("Task 19: ");
            var result19 = list.OrderBy(st => st.GroupNumber)
                               .GroupBy(st => st.GroupNumber)
                               .Select(st => st);
            foreach (var group in result19)
            {
                var groupNum = group.Select(st => st.GroupNumber).FirstOrDefault();
                Console.WriteLine("        Group {0}:", groupNum);
                Console.WriteLine(string.Join(Environment.NewLine, group));
            }
            Console.Write(separator);
        }

        private static void Task18(List<Student> list)
        {
            Console.WriteLine("Task 18: ");
            var result18 = from st in list
                           orderby st.GroupNumber
                           group st by st.GroupNumber;
            foreach (var gr in result18)
            {
                var groupNum = from st in gr
                               select st.GroupNumber;
                Console.WriteLine("        Group {0}:", groupNum.First());
                Console.WriteLine(string.Join(Environment.NewLine, gr));
            }
            Console.Write(separator);
        }

        private static void Task16(List<Student> list, List<Group> allGroups)
        {            
            Console.WriteLine("Task 16: ");
            var result16 = from gr in allGroups//With query syntax
                           where gr.DepartmentName == "Mathematics"
                           join st in list on gr.GroupNumber equals st.GroupNumber
                           select st;
            //var result16 = allGroups.Where(gr => gr.DepartmentName == "Mathematics")//Ext methods with lambda expr's
            //                        .Join(list, gr => gr.GroupNumber, st => st.GroupNumber, (gr, st) => st);
            Console.WriteLine("Students in \"Mathematics\" department: ");
            Console.WriteLine(string.Join(Environment.NewLine, result16));
            Console.Write(separator);
        }

        private static void Task15(List<Student> list)
        {
            Console.WriteLine("Task 15: ");
            var result15 = list.Where(st => st.FacultyNumber.Substring(st.FacultyNumber.Length - 2, 2) == "06")
                               .Select(st => st.Marks);
            foreach (var item in result15)
            {
                Console.WriteLine("Marks: {0}", string.Join(", ", item));
            }
            Console.Write(separator);
        }

        private static void Task14(List<Student> list)
        {
            Console.WriteLine("Task 14: ");
            var result14 = list.Where(st => st.Marks.FindAll(x => x == 2).Count == 2);
            Console.WriteLine(string.Join(Environment.NewLine, result14));
            Console.Write(separator);
        }

        private static void Task13(List<Student> list)
        {
            Console.WriteLine("Task 13: ");
            var result13 = from student in list
                           where student.Marks.Contains(6)
                           select new
                           {
                               FullName = student.FirstName + " " + student.LastName,
                               Marks = student.Marks
                           };
            foreach (var student in result13)
            {
                Console.WriteLine("{0}\nMarks: {1}", student.FullName, string.Join(", ", student.Marks));
            }
            Console.Write(separator);
        }

        private static void Task12(List<Student> list)
        {
            Console.WriteLine("Task 12: ");
            var result12 = from student in list
                           where (student.PhoneNumber.Substring(0, 2) == "02"
                                || student.PhoneNumber.Substring(0, 5) == "+3592")
                           select student;
            Console.WriteLine(string.Join(Environment.NewLine, result12));
            Console.Write(separator);
        }

        private static void Task11(List<Student> list)
        {
            Console.WriteLine("Task 11: ");
            var result11 = from student in list
                           where student.EMail.IndexOf("abv.bg") != -1
                           select student;
            Console.WriteLine(string.Join(Environment.NewLine, result11));
            Console.Write(separator);
        }

        private static void Task10(List<Student> list)
        {
            Console.WriteLine("Task 10: ");
            var result10 = list.Where(st => st.GroupNumber == 2)
                                   .OrderBy(st => st.FirstName);
            Console.WriteLine(string.Join(Environment.NewLine, result10));
            Console.Write(separator);
        }

        private static void Task9(List<Student> list)
        {
            Console.WriteLine("Task 9: ");
            var result9 = from student in list
                          where student.GroupNumber == 2
                          orderby student.FirstName
                          select student;
            Console.WriteLine(string.Join(Environment.NewLine, result9));
            Console.Write(separator);
        }
    }
}