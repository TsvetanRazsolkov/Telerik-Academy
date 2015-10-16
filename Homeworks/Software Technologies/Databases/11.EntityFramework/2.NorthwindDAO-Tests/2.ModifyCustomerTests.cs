namespace _2.NorthwindDAO_Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NorthwindContext;
    using NorthwindDAO;

    [TestClass]
    public class ModifyCustomerTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void ModifyExistingCustomerWithInvalidParameterShouldThrowTheHorribleException()
        {
            string customerId = "ALFKI";

            DAO.ModifyCustomer(customerId, null, null, null, null, "more than the fifteen symbols that are the constraint for city name");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ModifyUnexistingCustomerShouldThrowNullReferenceException()
        {
            DAO.ModifyCustomer("12345", "Papagal Company");
        }

        [TestMethod]
        public void ModifyExistingCustomerWithCorrectParametersShouldModifyTheCustomer()
        {
            string customerId = "ALFKI";

            DAO.ModifyCustomer(customerId, "yeah, you got it");

            using (var db = new NorthwindEntities())
            {
                var modifiedCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);

                Assert.AreEqual("yeah, you got it", modifiedCustomer.CompanyName);
            }
        }
    }
}
