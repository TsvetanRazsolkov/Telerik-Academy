namespace _02.Strategy
{
    public class LandShippingCompany : IShippingCompany
    {
        public void Deliver(string package)
        {
            System.Console.WriteLine("Todoof, todoof, todoof...");
            System.Console.WriteLine("Delivering by train a package of {0}.", package);
        }
    }
}
