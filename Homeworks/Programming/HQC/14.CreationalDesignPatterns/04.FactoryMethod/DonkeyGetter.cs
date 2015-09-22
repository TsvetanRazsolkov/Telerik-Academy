namespace _04.FactoryMethod
{
    /// <summary>
    /// Object creating subclass
    /// </summary>
    public class DonkeyGetter : IAnimalGetter
    {
        public Animal GetAnimal()
        {
            return new Donkey();
        }
    }
}
