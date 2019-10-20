namespace Homework.QAAutomation
{
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
   public class QAAutomationTest
    {
        private ChromeDriver _driver;
        private SoftUniPage _softuniPage;
        private QACoursePage _qacoursePage;

        [SetUp]
        public void ClassInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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
