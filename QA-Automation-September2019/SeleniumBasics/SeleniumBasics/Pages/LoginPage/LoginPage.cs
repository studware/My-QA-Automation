namespace SeleniumBasics.Pages
{
    using OpenQA.Selenium;

    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        { }

        ////*[@id="content-push"]/div/div/div[2]/div/div/a
        public IWebElement CreateUserLink => Wait.Until(d => { return d.FindElement(By.PartialLinkText(@"Create a new account")); });
    }
}
