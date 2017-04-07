using ATSimService.LogicServices.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ATSimWebTest
{
    [TestClass]

    public class Class1
    {
        private readonly ILoginService loginService;
        
        public Class1(ILoginService loginService) {
            this.loginService = loginService;
        }

        [TestMethod]
        public void TestMethodPassing()
        {
            ATSimWeb.Controllers.LoginController controller = new ATSimWeb.Controllers.LoginController(loginService);
            var result = controller.Login("gordon", "123456", new double[] { 123.22, 22.31 }, true);
            if(result is StatusCodeResult)
            {
                var statusCodeResult = (StatusCodeResult)result;
                Assert.AreEqual(statusCodeResult.StatusCode, HttpStatusCode.OK);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethodFailing()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestStringEqual()
        {
            var blogname = "linezero";
            Assert.AreEqual(blogname, "LineZero");
        }
    }
}
