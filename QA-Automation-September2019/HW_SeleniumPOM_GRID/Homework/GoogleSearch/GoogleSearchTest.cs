namespace Homework.GoogleSearch
{
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public partial class GoogleSearchTest
    {
        private ChromeDriver _driver;
        private GoogleSearchPage _googleSearchPage;

        [OneTimeSetUp]
        public void TestInitialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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
