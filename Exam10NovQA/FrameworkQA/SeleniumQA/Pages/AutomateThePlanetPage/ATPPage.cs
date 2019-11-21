namespace SeleniumQA.Pages.AutomateThePlanetPage
{
	using System;
	using OpenQA.Selenium;

	public partial class ATPPage : BasePage
	{
		public ATPPage(IWebDriver driver) : base(driver)
		{
		}

		public double Position
		{
			get
			{
				IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
				var value = Convert.ToDouble(executor.ExecuteScript("return window.pageYOffset;"));
				return value;
			}
		}

		public void ScrollTo(IWebElement element)
		{
			((IJavaScriptExecutor) Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
		}

		public void ScrollToTop()
		{
			((IJavaScriptExecutor) Driver).ExecuteScript("window.scrollTo(0, 0)");
		}

        public void ScrollBelowNavigation()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0, -100)");  
        }
    }
}
