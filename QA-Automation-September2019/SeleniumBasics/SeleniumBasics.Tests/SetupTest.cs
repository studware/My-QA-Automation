namespace SeleniumBasics
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.IO;
    using System.Reflection;

    public class SetupTest
    {
        //Arrange
        internal IWebDriver driver;
        internal WebDriverWait wait;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));  // driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }
    }
}
