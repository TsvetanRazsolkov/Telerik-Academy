namespace _02.Strategy
{
    using System;

    public class Example
    {
        public static void Main()
        {
            var continentalLogisticsCorp = new LogisticsCorporation(new LandShippingCompany());

            string package = "shoe laces";

            continentalLogisticsCorp.Deliver(package);

            var worldWideLogisticsCorp = new LogisticsCorporation(new AirShippingCompany());
            string anotherPackage = "1 tomato and 3 peppers";

            worldWideLogisticsCorp.Deliver(anotherPackage);
        }
    }
}
