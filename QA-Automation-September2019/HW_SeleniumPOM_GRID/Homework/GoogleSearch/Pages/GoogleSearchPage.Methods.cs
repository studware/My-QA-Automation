

namespace Homework.GoogleSearch
{
    using OpenQA.Selenium;

    public partial class GoogleSearchPage : BasePage
    {
        public GoogleSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToSearchResult()
        {
            Navigate("https://www.google.com/");
            SearchInput.SendKeys("Selenium");
            Logo.Click();
            SearchButton.Click();
            SeleniumResult.Click();
        }
    }
}