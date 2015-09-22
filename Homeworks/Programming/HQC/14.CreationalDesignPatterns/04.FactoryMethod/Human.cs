namespace _04.FactoryMethod
{
    /// <summary>
    /// Concrete product class
    /// </summary>
    public class Human : Animal
    {
        public Human()
        {
            this.NumberOfLegs = 2;
        }
    }
}
