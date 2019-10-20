namespace Homework.GoogleSearch
{
    using OpenQA.Selenium;

    public class GoogleSearchPage : BasePage
    {
        public GoogleSearchPage(IWebDriver driver) : base(driver)
        {
        }

       public  IWebElement GoogleSearchBar => Driver.FindElement(By.Name("q"));      
    }
}
