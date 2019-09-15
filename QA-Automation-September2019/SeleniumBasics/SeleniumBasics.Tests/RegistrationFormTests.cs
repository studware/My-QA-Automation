namespace SeleniumBasics
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    [TestFixture]
    public class RegistrationFormTests : SetupTest
    {
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void FillRegistrationForm()
        {
            //Arrange
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            IWebElement signInButton = driver.FindElement(By.CssSelector(".header_user_info"));    // IWebElement signInButton = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a"));

            //Act
            signInButton.Click();
            IWebElement eMailInput = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("email_create")); });
            eMailInput.SendKeys("peter@mail.bg");

            IWebElement submitCreate = driver.FindElement(By.Id("SubmitCreate"));
            submitCreate.Click();

            //Assert
            IWebElement createAccountForm = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("create-account_form")); });

//            string formLogo = createAccountForm.Text.Trim().Substring(0, 17);
//            string url = driver.Url;
//            Assert.IsNotNull(formLogo);
//            Assert.AreEqual("CREATE AN ACCOUNT", formLogo);
//            Assert.IsNotNull(url);
//            Assert.AreEqual("http://automationpractice.com/index.php?controller=authentication&back=my-account", url); 

            var actualEmail = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("email")); });
            Assert.AreEqual(eMailInput.Text, actualEmail.Text);
        }
     }
}
