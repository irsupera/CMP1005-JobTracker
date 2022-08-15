using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
//using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CMP1005_JobTracker_Integration
{
    [TestClass]
    public class IntegrationTest3
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Setup()
        {
            //new DriverManager().SetUpDriver(new ChromeConfig());
            //_webDriver = new ChromeDriver();
            //_webDriver.Url = "https://localhost:5001/Reminder/Create";
            //_webDriver.Navigate();

            _webDriver = new SafariDriver();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Reminder/Create");
            _webDriver.Navigate().Refresh();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var input_pos = _webDriver.FindElement(By.Id("Detail"));
            input_pos.Click();
            input_pos.SendKeys("Follow-up schedule for next week");

            var input_com = _webDriver.FindElement(By.Id("DateTime"));
            input_pos.Click();
            input_pos.SendKeys("08/15/2022 08:00");
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
