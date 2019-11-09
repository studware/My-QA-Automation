namespace SeleniumQA.Pages
{
	using System;
    using System.Threading;
    using OpenQA.Selenium;
	using OpenQA.Selenium.Support.UI;

	public class BasePage
	{
		public BasePage(IWebDriver driver)
		{
			Driver = driver;
		}

		public IWebDriver Driver { get; }

		public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
    }    
}
