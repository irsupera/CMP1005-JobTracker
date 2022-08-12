using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
//using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CMP1005_JobTracker_Integration
{
    [TestClass]
    public class IntegrationTest1
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Setup()
        {
            //new DriverManager().SetUpDriver(new ChromeConfig());
            //_webDriver = new ChromeDriver();
            //_webDriver.Url = "https://localhost:5001/Job/Create";
            //_webDriver.Navigate();

            _webDriver = new SafariDriver();
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Job/Create");
            _webDriver.Navigate().Refresh();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var input_pos = _webDriver.FindElement(By.Id("Position"));
            input_pos.Click();
            input_pos.SendKeys("Developer");

            var input_com = _webDriver.FindElement(By.Id("Company"));
            input_pos.Click();
            input_pos.SendKeys("CompanyX");

            var input_det = _webDriver.FindElement(By.Id("Detail"));
            input_pos.Click();
            input_pos.SendKeys("Details here");

            var input_sta = _webDriver.FindElement(By.Id("Detail"));
            input_pos.Click();
            input_pos.SendKeys("In-progress");
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
