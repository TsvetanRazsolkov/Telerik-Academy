using System;

class AgeAfterTenYears
{
    static void Main()
    {
        Console.Write("Enter your birthday in the format dd:mm:yyyy and press ENTER: ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());
        int age = 0;
        while ((birthDate = birthDate.AddYears(1)) < DateTime.Now)
        {
            age++;
        }
        Console.WriteLine("You are now {0} years old.", age);
        Console.WriteLine("In 10 years you will be {0} years old.", age + 10);
    }
}
