namespace _02.Strategy
{
    public class WaterShippingCompany : IShippingCompany
    {
        public void Deliver(string package)
        {
            System.Console.WriteLine("Sail, sail, sail...");
            System.Console.WriteLine("Delivering by ship a package of {0}.", package);
        }
    }
}
