namespace Homework.QAAutomation
{
    using OpenQA.Selenium;

    public partial class SoftUniPage
    {  
        public IWebElement PushNavBarButton => Driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/a/span"));
        
        public IWebElement PushQAButton => Driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/div/div/div[2]/div[2]/div/div[1]/ul[2]/div[1]/ul/li/a"));
    }
}
