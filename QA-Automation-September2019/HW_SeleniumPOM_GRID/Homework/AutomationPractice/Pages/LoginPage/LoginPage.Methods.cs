namespace Homework.Pages
{
    using Homework.Extensions;
    using Homework.Utilities;
    using OpenQA.Selenium;

    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public string NavigateToRegPage(LoginPage loginPage)
        {
            loginPage.Navigate("http://automationpractice.com/index.php?controller=my-account");
            string inputEmail = RandomGenerator.GenerateMail();
            loginPage.Email.Type(inputEmail);
            loginPage.Submit.Click();
            return inputEmail;
        }
    }
}
