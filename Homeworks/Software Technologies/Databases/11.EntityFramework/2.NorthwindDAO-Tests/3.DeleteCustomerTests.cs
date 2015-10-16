namespace _2.NorthwindDAO_Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NorthwindContext;
    using NorthwindDAO;

    [TestClass]
    public class DeleteCustomerTests
    {     
        [TestMethod]
        public void DeletingExistingNotConnectedCustomerShouldDeleteTheCustomer()
        {
            string customerId = "blaba";

            DAO.InsertCustomer(customerId, "some company");

            DAO.DeleteCustomer(customerId);

            using (var db = new NorthwindEntities())
            {
                var deletedCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);

                Assert.IsNull(deletedCustomer);
            }
        }
    }
}
