namespace SeleniumTests.Pages.ATP
{
    using OpenQA.Selenium;
    using System;

    public partial class ATP_Page: BasePage
    {
        private IJavaScriptExecutor _js;

        public ATP_Page(IWebDriver driver) : base(driver)
        {
            _js = (IJavaScriptExecutor)Driver;
        }

        public double Position
        {
            get
            {
                double value = Convert.ToDouble(_js.ExecuteScript("return window.pageYOffset;"));
                return value;
            }
        }

        public void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ScrollToTop()
        {
            _js.ExecuteScript("window.scrollTo(0, 0)");
        }

        public void ScrollBelowNavigation()
        {
            _js.ExecuteScript("window.scrollBy(0, -120)");
        }
    }
}
