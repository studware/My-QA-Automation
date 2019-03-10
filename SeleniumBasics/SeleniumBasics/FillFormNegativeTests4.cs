namespace SeleniumBasics
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System.Threading;

    [TestFixture]
    public class FillFormNegativeTests4 : SetupTest
    {
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void EmailMissingTest()
        {
            //Arrange
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            IWebElement signInButton = driver.FindElement(By.CssSelector(".header_user_info"));
            signInButton.Click();

            //Act
            IWebElement eMailInput = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("email_create")); });
            eMailInput.SendKeys(string.Empty);
            IWebElement submitCreate = driver.FindElement(By.Id("SubmitCreate"));
            submitCreate.Click();

            Thread.Sleep(2000);

            //Assert
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='create_account_error']/ol/li"));
            Assert.AreEqual("Invalid email address.", errorMessage.Text.Trim());

            //Arrange
            eMailInput.SendKeys("sdfgh@hjk.asd");
            submitCreate.Click();
            Thread.Sleep(5000);
            IWebElement submitAccountButton = wait.Until<IWebElement>(s => { return s.FindElement(By.Id("submitAccount")); });

            //Act
            submitAccountButton.Click();

            Thread.Sleep(2000);

            //Assert
            errorMessage = driver.FindElement(By.XPath("//*[@id='center_column']/div/p"));
            Assert.AreEqual("There are 8 errors", errorMessage.Text.Trim());
        }
    }
}

