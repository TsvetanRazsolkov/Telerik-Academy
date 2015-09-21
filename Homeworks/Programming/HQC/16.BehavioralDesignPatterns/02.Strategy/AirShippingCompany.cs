namespace _02.Strategy
{
    public class AirShippingCompany : IShippingCompany
    {
        public void Deliver(string package)
        {
            System.Console.WriteLine("Fly, fly, fly...");
            System.Console.WriteLine("Delivering by aeroplane a package of {0}.", package);
        }
    }
}
