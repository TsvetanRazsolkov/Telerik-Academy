namespace _2.NorthwindDAO_Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NorthwindContext;
    using NorthwindDAO;

    [TestClass]
    public class InsertCustomerTests
    {
        // More of those could be done, using the constraints of the data base rows, but one with null should suffice for the purpose of the exercise;
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void InsertingCustomerWithInvalidParameterShouldThrowTheHorribleException()
        {
            DAO.InsertCustomer(null, null);
        }

        [TestMethod]
        public void InsertingCustomerWithCorrectParametersShouldInsertTheCustomer()
        {
            string customerId = "zyxwv";

            DAO.InsertCustomer(customerId, "pesho's company");

            using (var db = new NorthwindEntities())
            {
                var insertedCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);

                Assert.AreEqual("pesho's company", insertedCustomer.CompanyName);
            }
        }
    }
}
