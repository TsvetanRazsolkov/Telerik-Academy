namespace Task2_MakePerson
{
    using System;

    public class PersonMaker
    {
        public static void Main()
        {
            Person firstPerson = MakePerson(25);
            Person secondPerson = MakePerson(26);

            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
        }

        public static Person MakePerson(int personAge)
        {
            Person newPerson = new Person();
            newPerson.Age = personAge;

            if (personAge % 2 == 0)
            {
                newPerson.Name = "Батката";
                newPerson.Gender = Gender.Male;
            }
            else
            {
                newPerson.Name = "Мацето";
                newPerson.Gender = Gender.Female;
            }

            return newPerson;
        }
    }
}