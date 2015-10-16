namespace _7.ConcurrentChanges
{
    using System;
    using System.Linq;

    using NorthwindContext;

    public class Program
    {
        public static void Main()
        {
            // By default EF uses no concurrency control (last write wins) which allows lost updates.
            // Enforcing optimistc concurrency checks must be explicitly configured by using ConcurrencyMode=Fixed:
            // https://msdn.microsoft.com/en-us/library/vstudio/bb738618(v=vs.100).aspx
            using (var dbCon1 = new NorthwindEntities())
            {    

                using (var dbCon2 = new NorthwindEntities())
                {
                    dbCon1.Customers.First().CompanyName = "Botush making";
                    dbCon2.Customers.First().CompanyName = "Grimm Brothers";
                    dbCon2.SaveChanges();
                    dbCon1.SaveChanges();
                }
            }
        }
    }
}
