namespace Homework.QAAutomation
{
    using OpenQA.Selenium;

    public class QACoursePage : BasePage
    {
        public QACoursePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement FoundResult => Driver.FindElement(By.XPath(@"/html/body/div[2]/header/h1"));

        public string Result()
        {
            var foundResult = FoundResult.Text;
            return foundResult;
        }
    }
}
