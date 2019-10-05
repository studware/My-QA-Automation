namespace SeleniumBasics.Pages.RegistrationPage
{
    using OpenQA.Selenium;

    public partial class RegistrationPage
    {
        public IWebElement FirstName => Driver.FindElement(By.Id("user_first_name"));

        public IWebElement LastName => Driver.FindElement(By.Id("user_last_name"));

        public IWebElement Mail => Driver.FindElement(By.Id("user_email"));

        public IWebElement Password => Driver.FindElement(By.Id("user_password"));

        public IWebElement ConfirmPassword => Driver.FindElement(By.Id("confirm_user_password"));

        public IWebElement SignUpButton => Driver.FindElement(By.Id("btn-signup"));

        public IWebElement PrivacyCheckBox => Driver.FindElement(By.Id("user_terms"));
    }
}
