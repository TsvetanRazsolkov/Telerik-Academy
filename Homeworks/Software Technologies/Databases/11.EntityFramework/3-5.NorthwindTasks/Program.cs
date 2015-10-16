namespace NorthwindTasks
{
    using System;
    using System.Linq;

    using NorthwindContext;

    public class Program
    {
        private const string Separator = "=====================================";
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                //ExecuteTaskThree(db);
                //ExecuteTaskFour(db);
                ExecuteTaskFive(db, "SP", new DateTime(1995, 1, 1), new DateTime(1999, 12, 12));
            }
            
        }
        
        /// <summary>
        /// Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        /// <param name="db">The database entity</param>
        private static void ExecuteTaskThree(NorthwindEntities db)
        {
            Console.WriteLine("Task 3: ");

            var customers = db.Customers
                .Where(c => c.Orders.Any(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada"))
                .ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ContactName + " - " + customer.CompanyName);
            }

            Console.WriteLine(Separator);
        }
        
        /// <summary>
        /// Implement previous by using native SQL query and executing it through the DbContext.
        /// </summary>
        /// <param name="db">The database entity</param>
        private static void ExecuteTaskFour(NorthwindEntities db)
        {
             Console.WriteLine("Task 4: ");

             string query = @"SELECT DISTINCT(c.ContactName + ' ' + c.CompanyName)
                             FROM Customers c
                             JOIN Orders o
                             ON c.CustomerID = o.CustomerID
                             WHERE YEAR(o.ShippedDate) = 1997 AND o.ShipCountry = 'Canada'";

             var customers = db.Database.SqlQuery<string>(query);

             foreach (var customer in customers)
             {
                 Console.WriteLine(customer);
             }

             Console.WriteLine(Separator);
        }

        /// <summary>
        /// Write a method that finds all the sales by specified region and period (start / end dates).
        /// </summary>
        /// <param name="db">The database entity</param>
        private static void ExecuteTaskFive(NorthwindEntities db, string region, DateTime start, DateTime end)
        {
            Console.WriteLine("Task 5: ");

            var sales = db.Orders
                .Where(o => o.ShipRegion == region && start <= o.OrderDate.Value && o.OrderDate.Value <= end)
                .ToList();

            if (sales.Count != 0)
            {
                foreach (var sale in sales)
                {
                    Console.WriteLine("Customer - {0}, Order date - {1}", sale.Customer.ContactName, sale.OrderDate.Value.ToShortDateString());
                }
            }
            else
            {
                Console.WriteLine("No sale in the specified region and timeframe.");
            }
        }
    }
}
