namespace Homework.GoogleSearch
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public partial class GoogleSearchTest
    {
        private IWebDriver _driver;
        private GoogleSearchPage _googleSearchPage;

        [OneTimeSetUp]
        public void TestInitialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";

            _driver = new RemoteWebDriver(new Uri("http://126.174.158.1:48733/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(20));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();

            _googleSearchPage = new GoogleSearchPage(_driver);
        }

        [Test]
        public void NavigateToGoogleSearchResult()
        {
            _googleSearchPage.NavigateToSearchResult();

            _googleSearchPage.AssertPageTitle("Selenium - Web Browser Automation");

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }
    }
}
