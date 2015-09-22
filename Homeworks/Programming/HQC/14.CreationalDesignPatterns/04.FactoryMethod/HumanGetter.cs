namespace _04.FactoryMethod
{
    /// <summary>
    /// Object creating subclass
    /// </summary>
    public class HumanGetter : IAnimalGetter
    {
        public Animal GetAnimal()
        {
            return new Human();
        }
    }
}
