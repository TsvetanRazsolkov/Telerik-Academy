using System;

class GravityOnTheMoon
{
    static void Main()
    {
        // The gravitational field of the Moon is approximately 17% of that on the Earth. Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
        Console.Write("Enter your weight in kilograms and press ENTER: ");

        double weightOnEarth;
        if ((double.TryParse(Console.ReadLine(), out weightOnEarth)) && (weightOnEarth >= 0))
        {
            double weightOnMoon = (17 * weightOnEarth) / 100;
            Console.WriteLine("On Earth you weigh {0} kg.", weightOnEarth);
            Console.WriteLine("On Moon you'll weigh {0} kg.", weightOnMoon);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}