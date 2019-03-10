namespace SeleniumBasics.Pages.RegistrationPage
{
    using OpenQA.Selenium;
    using SeleniumBasics.Models;

    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public string Url => "https://courses.ultimateqa.com/users/sign_up";

        public void FillForm(RegistrationUser user)
        {
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Mail.SendKeys(user.Email);
            Password.SendKeys(user.Password);
            PrivacyCheckBox.Click();
            SignUpButton.Click();
        }
    }
}
