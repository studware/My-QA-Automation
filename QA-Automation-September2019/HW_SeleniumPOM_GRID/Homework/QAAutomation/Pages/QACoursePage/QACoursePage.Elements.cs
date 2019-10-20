namespace Homework.QAAutomation
{
    using OpenQA.Selenium;

    public partial class QACoursePage
    {
        public IWebElement FoundResult => Driver.FindElement(By.XPath(@"/html/body/div[2]/header/h1"));
    }
}
