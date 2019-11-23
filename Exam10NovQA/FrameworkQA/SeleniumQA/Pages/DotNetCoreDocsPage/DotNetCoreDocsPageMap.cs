namespace SeleniumQA.Pages.DotNetCoreDocsPage
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DotNetCoreDocsPage
    {
        public IWebElement Guide1 => Driver.FindElement(By
            .XPath("//*[@id='dotnetguides']/li[2]/div/div/div/div[2]/h3/a"));    // li[2]
        //public IWebElement Guide2 => Driver.FindElement(By
        //    .XPath("//*[@id='dotnetguides']/li[5]/div/div/div/div[2]/h3/a"));     // li[5]
        //public IWebElement Guide3 => Driver.FindElement(By
        //    .XPath("//*[@id='dotnetguides']/li[7]/div/div/div/div[2]/h3/a"));     // li[7]

        public IWebElement Topic1 => Wait.Until(SeleniumExtras.WaitHelpers
            .ExpectedConditions
            .ElementToBeClickable(By.XPath("//*[@id='affixed-left-container']/ul/li[16]")));   // Unit Testing li[16]  
        //public IWebElement Topic2 => Wait.Until(SeleniumExtras.WaitHelpers
        //    .ExpectedConditions
        //    .ElementToBeClickable(By.XPath("//*[@id='affixed-left-container']/ul/li[6]")));    // C# Concepts li[6]  
        //public IWebElement Topic3 => Wait.Until(SeleniumExtras.WaitHelpers
        //    .ExpectedConditions
        //    .ElementToBeClickable(By.XPath("//*[@id='affixed-left-container']/ul/li[7]")));    // Language Features li[7]

        public IWebElement Article1 => Driver.FindElement(By
            .XPath("//*[@id='affixed-left-container']/ul/li[16]/ul/li[4]/a")); // C# unit testing with NUnit li[16]....li[4]
        //public IWebElement Article2 => Driver.FindElement(By
        //    .XPath("//*[@id='affixed-left-container']/ul/li[6]/ul/li[5]/a"));   // Basic Types li[6]....li[5]
        //public IWebElement Article3 => Driver.FindElement(By
        //    .XPath("//*[@id='affixed-left-container']/ul/li[7]/ul/li[8]/a"));    // Delegates li[7]....li[8]

        public IWebElement Navigation => Wait.Until(d => { return d.FindElement(By.XPath("//*[@id='side-doc-outline']/ol")); });
        public List<IWebElement> ItemLinks => Navigation.FindElements(By.TagName("a")).ToList();
        public List<string> NavigationLinksNames => Navigation
            .FindElements(By.TagName("a"))
            .Select(h => h.Text.Trim())
            .ToList();

        public IWebElement Article => Driver.FindElement(By.Id("main"));
        public List<string> SectionsNames => Article
            .FindElements(By.TagName("h2"))
            .ToList()
            .Select(h => h.Text.Trim())
            .ToList();

        public IWebElement YesButton => Driver.FindElement(By.XPath("//*[@id='affixed-right-container']/div/div[1]/div/div/button[1]"));
        public IWebElement SkipButton => Driver.FindElement(By.XPath("//*[@id='affixed-right-container']/div/div[1]/form/div[2]/button[1]"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@id='affixed-right-container']/div/div[1]/form/div[2]/button[2]"));
        public IWebElement ThankYou => Driver.FindElement(By.XPath("//*[@id='affixed-right-container']/div/div[2]/p"));
        public IWebElement FeedBack => Wait.Until(SeleniumExtras.WaitHelpers
            .ExpectedConditions
            .ElementToBeClickable(By
            .XPath("//*[@id='affixed-right-container']//textarea[@id='rating-feedback-mobile']")));

        //public IWebElement[] GuideLinks
        //{
        //    get
        //    {
        //        return new IWebElement[] { Guide1, Guide2, Guide3 };
        //    }
        //}
        //public IWebElement[] TopicExpanders
        //{
        //    get
        //    {
        //        return new IWebElement[] { Topic1, Topic2, Topic3 };
        //    }
        //}

        //public IWebElement[] ArticleLinks
        //{
        //    get
        //    {
        //        return new IWebElement[] { Article1, Article2, Article3 };
        //    }
        //}
    }
}
