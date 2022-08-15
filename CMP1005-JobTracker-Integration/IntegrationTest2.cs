using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
//using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CMP1005_JobTracker_Integration
{
    [TestClass]
    public class IntegrationTest2
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Setup()
        {
            //new DriverManager().SetUpDriver(new ChromeConfig());
            //_webDriver = new ChromeDriver();
            //_webDriver.Url = "https://localhost:5001/DTR/Create";
            //_webDriver.Navigate();

            _webDriver = new SafariDriver();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/DTR/Create");
            _webDriver.Navigate().Refresh();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var input_pos = _webDriver.FindElement(By.Id("TimeIn"));
            input_pos.Click();
            input_pos.SendKeys("08/14/2022 08:00");

            var input_com = _webDriver.FindElement(By.Id("TimeOut"));
            input_pos.Click();
            input_pos.SendKeys("08/14/2022 17:00");
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
