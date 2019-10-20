namespace Homework
{
    using Homework.Pages;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class POMTests
    {
        private HomePage _homePage;
        private LoginPage _loginPage;
        private RegistrationPage _regPage;

        private RegistrationUser _user;

        private IWebDriver _driver;

        [SetUp]
        public void ClassInit()
        {
            ChromeOptions options = new ChromeOptions();
            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";

            _driver = new RemoteWebDriver(new Uri("http://126.174.158.1:48733/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(20));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();
            //      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // This will slowdown all the tests

            _homePage = new HomePage(_driver);
            _loginPage = new LoginPage(_driver);
            _regPage = new RegistrationPage(_driver);

            _user = UserFactory.CreateValidUser();

        }

        [Test]
        public void AutomationPracticeRegistrationPageOpen()
        {
            //Arrange&Act          
            _homePage.NavigateToLoginPage(_homePage);
            string expected =_loginPage.NavigateToRegPage(_loginPage);
            string text = _regPage.EmailText.GetAttribute("value");

            //Assert
            Assert.AreEqual(expected, text);
        }

        [Test]
        public void FillRegistrationFormMissingPhoneNumber()
        {
            _user.Phone = "";
            _loginPage.NavigateToRegPage(_loginPage);
            _regPage.FillForm(_user);
            
            _regPage.AssertErrorMessage("You must register at least one phone number.");

        }

        [Test]
        public void FillRegistrationFormMissingLastName()
        {
            _user.LastName = "";
            _loginPage.NavigateToRegPage(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("lastname is required.");

        }

        [Test]
        public void FillRegistrationFormMissingFirstName()
        {
            _user.FirstName = "";
            _loginPage.NavigateToRegPage(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("firstname is required.");

        }

        [Test]
        public void FillRegistrationFormMissingPassword()
        {
            _user.Password = "";
            _loginPage.NavigateToRegPage(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("passwd is required.");
        }

        [Test]
        public void FillRegistrationFormMissingAddress()
        {
            _user.Address = "";
            _loginPage.NavigateToRegPage(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("address1 is required.");
        }

        [Test]
        public void FillRegistrationFormMissingCity()
        {
            _user.City = "";
            _loginPage.NavigateToRegPage(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("city is required.");
        }

        [Test]
        public void FillRegistrationFormWithInvalidPostCode()
        {
            _user.PostCode = "d4g6";
            _loginPage.NavigateToRegPage(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("The Zip/Postal code you've entered is invalid. It must follow this format: 00000");
        }


        [TearDown]
        public void CleanUp()
        {
            // TO DO: Move this code and add it to the BaseTest.CleanUp member!
            _driver.Quit();

            var name = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if (result != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                //     var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //     var directory = Directory.GetCurrentDirectory();

                var fullPath = Path.GetFullPath("..\\..\\..\\Screenshots\\");
                screenshot.SaveAsFile(fullPath + name + ".png", ScreenshotImageFormat.Png);
            }
        }
    }
}
