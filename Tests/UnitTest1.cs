using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRentalSystem;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConnectionValidation()
        {
            Assert.AreEqual(true, new DBContextHelper().VerifyConn());
        }

        [TestMethod]
        public void ValuesValidation()
        {
            DBContextHelper database = new DBContextHelper();
            DataTable table = database.GetAllCust();
            Assert.IsNotNull(table);
        }
    }
}
