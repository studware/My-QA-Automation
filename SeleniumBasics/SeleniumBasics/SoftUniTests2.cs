namespace SeleniumBasics
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    [TestFixture]
    public class SoftUniTests2: SetupTest
    {
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void EnterSoftUni()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://softuni.bg");
            IWebElement courses = driver.FindElement(By.XPath("//*[@id='header-nav']/div[1]/ul/li[2]/a/span"));

            //Act
            courses.Click();
            string coursesText = courses.Text;

            //Assert
            Assert.AreEqual("ОБУЧЕНИЯ", coursesText);

            //Arrange
            IWebElement qa = driver.FindElement(By.PartialLinkText("QA Automation - януари 2019")); // IWebElement qa = driver.FindElement(By.XPath(@".//*/div/div/div[2]/div[2]/div/div[1]/ul[1]/div[1]/h2/a"));

            //Act
            qa.Click();
            IWebElement qaAuto = driver.FindElement(By.XPath("/html/body/div[2]/header/h1"));
            qaAuto.Click();
            string courseName = qaAuto.Text;

            //Assert
            Assert.IsNotNull(courseName);
            Assert.AreEqual("QA Automation - януари 2019", courseName);
        }
    }
}
