namespace SeleniumBasics.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    [TestFixture]
    public class SoftUniTests: SetupTest
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
            string expectedText = "QA Automation - септември 2019";
            IWebElement qa = driver.FindElement(By.PartialLinkText(expectedText)); // IWebElement qa = driver.FindElement(By.XPath(@".//*/div/div/div[2]/div[2]/div/div[1]/ul[1]/div[1]/h2/a"));
            qa.Click();

            //Act
            IWebElement qaAuto = driver.FindElement(By.TagName("h1"));
            string courseName = qaAuto.Text;

            //Assert
            Assert.IsNotNull(courseName);
            Assert.AreEqual(expectedText, courseName);
        }
    }
}
