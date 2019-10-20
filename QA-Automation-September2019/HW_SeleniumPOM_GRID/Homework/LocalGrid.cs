namespace Homework
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using System;

    [TestFixture]
    public class LocalGrid
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();

            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";

            _driver = new RemoteWebDriver(new Uri("http://192.124.257.24:48129/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(20));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void FirstTest()
        {
            _driver.Navigate().GoToUrl(@"https://automatetheplanet.com/category/series/webdriver/");

            var link = _driver.FindElement(By.PartialLinkText("Cloud- BrowserStack"));
            int linkY = link.Location.Y;
            int linkX = link.Location.X;
            var jsToBeExecuted = $"window.scroll({linkX}, {linkY - 362});";
            ((IJavaScriptExecutor)_driver).ExecuteScript(jsToBeExecuted);
            link.Click();

            Assert.AreEqual("Execute UI Tests in the Cloud- BrowserStack", _driver.Title);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

