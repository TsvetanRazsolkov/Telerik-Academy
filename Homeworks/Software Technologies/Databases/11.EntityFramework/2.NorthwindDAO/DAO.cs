namespace NorthwindDAO
{
    using System.Linq;

    using NorthwindContext;
    using System;

    public static class DAO
    {
        public static void InsertCustomer(string customerId, string companyName, string contactName = null, string contactTitle = null,
                                          string address = null, string city = null, string region = null, string postalCode = null,
                                          string country = null, string phone = null, string fax = null)
        {


            using (var db = new NorthwindEntities())
            {
                var customer = new Customer
                {
                    CustomerID = customerId,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

                db.Customers.Add(customer);

                db.SaveChanges();
            }
        }

        public static void ModifyCustomer(string customerId, string companyName, string contactName = null, string contactTitle = null,
                                          string address = null, string city = null, string region = null, string postalCode = null,
                                          string country = null, string phone = null, string fax = null)
        {
            using (var db = new NorthwindEntities())
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);

                if (!string.IsNullOrEmpty(companyName))
                {
                    customer.CompanyName = companyName;
                }

                if (!string.IsNullOrEmpty(contactName))
                {
                    customer.ContactName = contactName;
                }

                if (!string.IsNullOrEmpty(contactTitle))
                {
                    customer.ContactTitle = contactTitle;
                }

                if (!string.IsNullOrEmpty(address))
                {
                    customer.Address = address;
                }

                if (!string.IsNullOrEmpty(city))
                {
                    customer.City = city;
                }

                if (!string.IsNullOrEmpty(region))
                {
                    customer.Region = region;
                }

                if (!string.IsNullOrEmpty(postalCode))
                {
                    customer.PostalCode = postalCode;
                }

                if (!string.IsNullOrEmpty(country))
                {
                    customer.Country = country;
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    customer.Phone = phone;
                }

                if (!string.IsNullOrEmpty(fax))
                {
                    customer.Fax = fax;
                }

                db.SaveChanges();
            }
        }

        public static void DeleteCustomer(string customerId)
        {
            using (var db = new NorthwindEntities())
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);
                db.Customers.Remove(customer);

                db.SaveChanges();
            }
        }
    }
}
