namespace Homework.QAAutomation
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
   public class QAAutomationTest
    {
        private IWebDriver _driver;
        private SoftUniPage _softuniPage;
        private QACoursePage _qacoursePage;

        [SetUp]
        public void ClassInit()
        {
            ChromeOptions options = new ChromeOptions();
            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";

            _driver = new RemoteWebDriver(new Uri("http://126.174.158.1:48733/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(60));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            _driver.Manage().Window.Maximize();

            _softuniPage = new SoftUniPage(_driver);
            _qacoursePage = new QACoursePage(_driver);
        }

        [Test]
        public void QAAutomationPageTitleShouldBeCorrect()
        {
            _softuniPage.Navigate();
           
            Assert.AreEqual(_qacoursePage.Result(), "QA Automation - септември 2019");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
