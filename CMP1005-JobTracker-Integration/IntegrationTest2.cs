using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CMP1005_JobTracker_Test
{
    [TestClass]
    public class IntegrationTest2
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void Test_Title_DTRPage()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/DTR");
            Assert.IsTrue(_webDriver.Title.Contains("DTR Page"));
        }

        [TestMethod]
        public void Test_Create_DTR()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/DTR/Create");
            Assert.IsTrue(_webDriver.Title.Contains("Create DTR"));

            var input_in = _webDriver.FindElement(By.Id("TimeIn"));
            input_in.Click();
            input_in.SendKeys("08/14/2022 08:00");

            var input_out = _webDriver.FindElement(By.Id("TimeOut"));
            input_out.Click();
            input_out.SendKeys("08/14/2022 17:00");

            var input_cre = _webDriver.FindElement(By.Id("Create"));
            input_cre.Click();
        }

        [TestMethod]
        public void Test_Edit_DTR()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/DTR/Edit/1");
            Assert.IsTrue(_webDriver.Title.Contains("Edit DTR"));

            var input_out = _webDriver.FindElement(By.Id("TimeOut"));
            input_out.Click();
            input_out.SendKeys("08/14/2022 18:00");

            var input_sav = _webDriver.FindElement(By.Id("Save"));
            input_sav.Click();
        }

        [TestMethod]
        public void Test_Delete_DTR()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/DTR/Delete/1");
            Assert.IsTrue(_webDriver.Title.Contains("Delete DTR"));

            var input_del = _webDriver.FindElement(By.Id("Delete"));
            input_del.Click();
        }

        [TestMethod]
        public void Test_Details_DTR()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/DTR/Details/1");
            Assert.IsTrue(_webDriver.Title.Contains("DTR Details"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
