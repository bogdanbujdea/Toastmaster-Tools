using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ToastmasterTools.Core.Models.Reports;

namespace ToastmasterTools.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var report = new AuthenticationReport(true);
            Assert.AreEqual(true, report.Successful);
        }
    }
}
