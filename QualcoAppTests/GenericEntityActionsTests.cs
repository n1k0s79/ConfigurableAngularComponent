using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualcoApp.Controllers;
using QualcoApp.Models;

namespace QualcoAppTests
{
    [TestClass]
    public class GenericEntityActionsTests
    {
        [TestMethod]
        public void InvoiceCustomer()
        {
            var context = TestHelper.GetMockContext();
            var controller = new GenericEntityActionsController(context);
            var result = controller.EntityAction("Customer", "Invoice", 1);
            Assert.IsTrue(true); // TODO assert the effects on the mocked context
        }
    }
}
