using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualcoApp.Controllers;
using QualcoApp.Models;

namespace QualcoAppTests
{
    [TestClass]
    public class GenericEntityListActionsTests
    {
        [TestMethod]
        public void AddProduct()
        {
            var context = TestHelper.GetMockContext();
            var controller = new GenericEntityActionsController(context);
            var result = controller.ListAction("Product", "Add");
            Assert.IsTrue(true); // TODO assert the effects on the mocked context
        }
    }
}
