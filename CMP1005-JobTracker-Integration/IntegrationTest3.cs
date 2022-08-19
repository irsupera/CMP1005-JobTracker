using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CMP1005_JobTracker_Test
{
    [TestClass]
    public class IntegrationTest3
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void Test_Title_ReminderPage()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Reminder");
            Assert.IsTrue(_webDriver.Title.Contains("Reminder Page"));
        }

        [TestMethod]
        public void Test_Create_Reminder()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Reminder/Create");
            Assert.IsTrue(_webDriver.Title.Contains("Create Reminder"));

            var input_det = _webDriver.FindElement(By.Id("Detail"));
            input_det.Click();
            input_det.SendKeys("Follow-up schedule for next week");

            var input_dt = _webDriver.FindElement(By.Id("DateTime"));
            input_dt.Click();
            input_dt.SendKeys("08/15/2022 08:00");

            var input_cre = _webDriver.FindElement(By.Id("Create"));
            input_cre.Click();
        }

        [TestMethod]
        public void Test_Edit_Reminder()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Reminder/Edit/1");
            Assert.IsTrue(_webDriver.Title.Contains("Edit Reminder"));

            var input_dt = _webDriver.FindElement(By.Id("DateTime"));
            input_dt.Click();
            input_dt.SendKeys("08/16/2022 08:00");

            var input_sav = _webDriver.FindElement(By.Id("Save"));
            input_sav.Click();
        }

        [TestMethod]
        public void Test_Delete_Reminder()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Reminder/Delete/1");
            Assert.IsTrue(_webDriver.Title.Contains("Delete Reminder"));

            var input_del = _webDriver.FindElement(By.Id("Delete"));
            input_del.Click();
        }

        [TestMethod]
        public void Test_Details_Reminder()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Reminder/Details/1");
            Assert.IsTrue(_webDriver.Title.Contains("Reminder Details"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
