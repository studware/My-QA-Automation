namespace Homework
{
    using Homework.Pages;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class POMTests
    {
        private LoginPage _loginPage;
        private RegistrationPage _regPage;
        private RegistrationUser _user;
        private ChromeDriver _driver;

        [SetUp]
        public void ClassInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
      //      _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // This will slowdown all the tests

            _loginPage = new LoginPage(_driver);
            _regPage = new RegistrationPage(_driver);

            _user = UserFactory.CreateValidUser();

        }

        [Test]
        public void AutomationpracticeRegistrationPageOpen()
        {
            //Arrange          
            _regPage.Navigate(_loginPage);
            
            //Assert
            Assert.AreEqual("YOUR PERSONAL INFORMATION", _regPage.RegistrationForm.Text);
//            Assert.IsNotNull(_regPage.ActualEmail.Text);
        }

        [Test]
        public void FillRegistrationFormMissingPhoneNumber()
        {
            _user.Phone = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);
            
            _regPage.AssertErrorMessage("You must register at least one phone number.");

        }

        [Test]
        public void FillRegistrationFormMissingLastName()
        {
            _user.LastName = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("lastname is required.");

        }

        [Test]
        public void FillRegistrationFormMissingFirstName()
        {
            _user.FirstName = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("firstname is required.");

        }

        [Test]
        public void FillRegistrationFormMissingPassword()
        {
            _user.Password = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("passwd is required.");
        }

        [Test]
        public void FillRegistrationFormMissingAddress()
        {
            _user.Address = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("address1 is required.");
        }

        [Test]
        public void FillRegistrationFormMissingCity()
        {
            _user.City = "";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("city is required.");
        }

        [Test]
        public void FillRegistrationFormWithInvalidPostCode()
        {
            _user.PostCode = "d4g6";
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("The Zip/Postal code you've entered is invalid. It must follow this format: 00000");
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
