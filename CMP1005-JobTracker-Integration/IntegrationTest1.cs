using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CMP1005_JobTracker_Test
{
    [TestClass]
    public class IntegrationTest1
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void Test_Title_HomePage()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.IsTrue(_webDriver.Title.Contains("Home Page"));
        }

        [TestMethod]
        public void Test_Title_JobPage()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Job");
            Assert.IsTrue(_webDriver.Title.Contains("Job Page"));
        }

        [TestMethod]
        public void Test_Create_Job()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Job/Create");
            Assert.IsTrue(_webDriver.Title.Contains("Create Job"));

            var input_pos = _webDriver.FindElement(By.Id("Position"));
            input_pos.Click();
            input_pos.SendKeys("Developer");

            var input_com = _webDriver.FindElement(By.Id("Company"));
            input_com.Click();
            input_com.SendKeys("CompanyX");

            var input_det = _webDriver.FindElement(By.Id("Detail"));
            input_det.Click();
            input_det.SendKeys("Details here");

            var input_sta = _webDriver.FindElement(By.Id("Detail"));
            input_sta.Click();
            input_sta.SendKeys("In-progress");

            var input_cre = _webDriver.FindElement(By.Id("Create"));
            input_cre.Click();
        }

        [TestMethod]
        public void Test_Edit_Job()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Job/Edit/1");
            Assert.IsTrue(_webDriver.Title.Contains("Edit Job"));

            var input_sta = _webDriver.FindElement(By.Id("Status"));
            input_sta.Click();
            input_sta.SendKeys("Hired");

            var input_sav = _webDriver.FindElement(By.Id("Save"));
            input_sav.Click();
        }

        [TestMethod]
        public void Test_Delete_Job()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Job/Delete/1");
            Assert.IsTrue(_webDriver.Title.Contains("Delete Job"));

            var input_del = _webDriver.FindElement(By.Id("Delete"));
            input_del.Click();
        }

        [TestMethod]
        public void Test_Details_Job()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/Job/Details/1");
            Assert.IsTrue(_webDriver.Title.Contains("Job Details"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
