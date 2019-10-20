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
        private GoogleResultsPage _googleResultsPage;

        [SetUp]
        public void TestInitialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();

            _googleSearchPage = new GoogleSearchPage(_driver);
            _googleResultsPage = new GoogleResultsPage(_driver);

        }
                     
        [Test]
        public void SeleniumSearch()
        {
            _googleResultsPage.Navigate(_googleSearchPage);
            var foundResult = _driver.Title;
                       
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
