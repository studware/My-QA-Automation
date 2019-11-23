namespace SeleniumQA.Pages
{
	using System;
    using OpenQA.Selenium;
	using OpenQA.Selenium.Support.UI;

	public abstract class BasePage
	{
		public BasePage(IWebDriver driver)
		{
			Driver = driver;
		}

		public IWebDriver Driver { get; }
		public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        public int listIndex;

        public void Type(IWebElement element, string value)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            element.Clear();
            element.SendKeys(value);
        }
    }    
}
