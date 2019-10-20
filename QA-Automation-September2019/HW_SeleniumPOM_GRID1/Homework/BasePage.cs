namespace Homework
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public abstract class BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        public IWebDriver Driver => _driver;
        public WebDriverWait Wait => _wait;

        public virtual void Navigate(string url)
        {
            Driver.Url = url;
        }
    }
}
