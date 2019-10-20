namespace Homework.QAAutomation
{
    using OpenQA.Selenium;

    public partial class SoftUniPage : BasePage
    {
        public SoftUniPage(IWebDriver driver) : base(driver)
        {

        }

        public void Navigate()
        {
            Navigate("http://www.softuni.bg");
            PushNavBarButton.Click();
            PushQAButton.Click();
        }
    }
}
