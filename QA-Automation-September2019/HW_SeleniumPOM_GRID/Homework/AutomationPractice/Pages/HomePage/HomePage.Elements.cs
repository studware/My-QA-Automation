namespace Homework.Pages
{
    using OpenQA.Selenium;

    public partial class HomePage
    {
        public HomePage(IWebDriver driver)
            : base(driver)
        {

        }

    public IWebElement SignInButton => Driver.FindElement(By.PartialLinkText(@"Sign in"));
    }
}
