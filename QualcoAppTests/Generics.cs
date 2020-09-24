using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualcoApp.Controllers;
using QualcoApp.Models;

namespace QualcoAppTests
{
    [TestClass]
    public class Generics
    {
        [TestMethod]
        public void GetProperties()
        {
            var customer = new Customer() { Id = 12, Lastname = "Skalas", Firstname = "Kostas" };
            var descriptor = GenericEntityDescriptor.FromEntity(customer);
            Assert.IsTrue(descriptor.HasFieldWithValue("Id", "12"));
            Assert.IsTrue(descriptor.HasFieldWithValue("Lastname", "Skalas"));
            Assert.IsTrue(descriptor.HasFieldWithValue("Firstname", "Kostas"));
        }

        [TestMethod]
        public void GetActions()
        {
            var actions = GenericEntityActionsController.GetEntityListActions("Customer");
            Assert.AreEqual("Add", actions[0]);
            Assert.AreEqual("Remove", actions[1]);
        }
    }
}
