namespace SeleniumQA.Pages.DotNetCoreDocsPage
{
	using System;
	using OpenQA.Selenium;

	public partial class DotNetCoreDocsPage : BasePage
	{

        public DotNetCoreDocsPage(IWebDriver driver) : base(driver)
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

        public void SetTextAreaValue(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            executor.ExecuteScript("arguments[0].Value = 'bla-bla';", element);
        }
    }
}
