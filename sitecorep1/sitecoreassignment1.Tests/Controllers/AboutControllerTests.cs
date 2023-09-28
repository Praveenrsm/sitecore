using Microsoft.VisualStudio.TestTools.UnitTesting;
using sitecoreassignment1.Controllers;
using System;

namespace sitecoreassignment1.Tests.Controllers
{
    [TestClass]
    public class AboutControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new AboutController();
            var result = controller.Index();
            Assert.AreEqual(result,"as");
        }
    }
}
