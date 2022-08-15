using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMP1005_JobTracker.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMP1005_JobTracker_Test
{
    [TestClass]
    public class UnitTest1: ControllerBase
    {
        //private readonly JobTrackerContext _context;

        [TestMethod]
        public void TestJobIndex()
        {
            JobController controller = new JobController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestJobDetails()
        {
            JobController controller = new JobController();
            ViewResult result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void TestDTRIndex()
        {
            DTRController controller = new DTRController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDTRDetails()
        {
            DTRController controller = new DTRController();
            ViewResult result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void TestReminderIndex()
        {
            ReminderController controller = new ReminderController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestReminderDetails()
        {
            ReminderController controller = new ReminderController();
            ViewResult result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }
    }
}

