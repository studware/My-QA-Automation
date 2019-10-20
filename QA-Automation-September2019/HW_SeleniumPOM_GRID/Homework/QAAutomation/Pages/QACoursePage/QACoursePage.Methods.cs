namespace Homework.QAAutomation
{
    using OpenQA.Selenium;

    public partial class QACoursePage : BasePage
    {
        public QACoursePage(IWebDriver driver) : base(driver)
        {
        }

        public string Result()
        {
            var foundResult = FoundResult.Text;
            return foundResult;
        }
    }
}
