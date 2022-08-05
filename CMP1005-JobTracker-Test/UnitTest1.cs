using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMP1005_JobTracker.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMP1005_JobTracker_Test
{
    [TestClass]
    public class UnitTest1: ControllerBase
    {
        [TestMethod]
        public void TestIndex()
        {
            JobTrackerController controller = new JobTrackerController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDetails()
        {
            JobTrackerController controller = new JobTrackerController();
            ViewResult result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }
    }
}

