namespace SeleniumTests.Pages.Docker
{
    using OpenQA.Selenium;
    using System;

    public partial class DockerPage: BasePage
    {
        private IJavaScriptExecutor _js;

        public DockerPage(IWebDriver driver) : base(driver)
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
