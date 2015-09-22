namespace _04.FactoryMethod
{
    using System;

    public class Example
    {
        public static void Main()
        {
            IAnimalGetter[] animalFactories = new IAnimalGetter[2];
            animalFactories[0] = new HumanGetter();
            animalFactories[1] = new DonkeyGetter();

            Animal gosho = animalFactories[0].GetAnimal();
            Console.WriteLine("This is Gosho. He is a {0} and has {1} legs.", gosho.GetType().Name, gosho.NumberOfLegs);

            Animal pesho = animalFactories[1].GetAnimal();
            Console.WriteLine("This is Pesho. He is a {0} and has {1} legs.", pesho.GetType().Name, pesho.NumberOfLegs);
            
        }
    }
}
