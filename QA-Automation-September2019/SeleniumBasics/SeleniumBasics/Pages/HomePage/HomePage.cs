namespace SeleniumBasics.Pages
{
    using OpenQA.Selenium;

    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base (driver)
        {        }

        public IWebElement LoginForm => Driver.FindElement(By.PartialLinkText("Login automation"));
    }
}
