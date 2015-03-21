namespace AnimalHierarchy
{
    using System;
    using System.Text;

    public class AnimalHierarchyTest
    {
        private static readonly string separator = new string('-', Console.WindowWidth);

        static void Main()
        {
            Animal[] animals = new Animal[]{new Frog("Kermit", 4, Gender.Male),
                                            new Frog("Zhuzhi", 3, Gender.Female),
                                            new Kitten("Puff", 6),
                                            new Tomcat("Puss", 3),
                                            new Dog("Sharo", 8, Gender.Male),
                                            new Dog("Balkan", 12, Gender.Male),
                                            new Dog("Baikal", 4, Gender.Male),
                                            new Kitten("Shushi", 2),
                                            new Tomcat("Tom", 4),
                                            new Frog("Buba", 7, Gender.Female)};
            Console.WriteLine("  All animals: ");
            Console.WriteLine(AnimalsInfo(animals));
            Console.Write(separator);

            Type targetAnimals = typeof(Frog);
            double averageFrogAge = Animal.CalculateAverageAge(targetAnimals, animals);
            Console.WriteLine("Average age of all the frogs = {0} years", averageFrogAge);
            Console.Write(separator);

            targetAnimals = typeof(Dog);
            double averageDogAge = Animal.CalculateAverageAge(targetAnimals, animals);
            Console.WriteLine("Average age of all the dogs = {0} years", averageDogAge);
            Console.Write(separator);

            targetAnimals = typeof(Cat);
            double averageCatAge = Animal.CalculateAverageAge(targetAnimals, animals);
            Console.WriteLine("Average age of all the cats = {0} years", averageCatAge);
            Console.Write(separator);
        }

        private static string AnimalsInfo(Animal[] animals)
        {
            var animalInfo = new StringBuilder();

            foreach (var animal in animals)
            {
                animalInfo.AppendLine(animal.ToString());
            }

            return animalInfo.ToString();
        }
    }
}
