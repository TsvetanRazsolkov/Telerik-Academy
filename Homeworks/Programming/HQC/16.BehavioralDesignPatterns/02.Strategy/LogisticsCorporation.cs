namespace _02.Strategy
{
    using System.Collections.Generic;

    public class LogisticsCorporation
    {
        public LogisticsCorporation(IShippingCompany shippingCompany)
        {
            this.ShippingCompany = shippingCompany;
        }

        public IShippingCompany ShippingCompany { get; set; }

        public void Deliver(string package)
        {
            this.ShippingCompany.Deliver(package);
        }
    }
}
