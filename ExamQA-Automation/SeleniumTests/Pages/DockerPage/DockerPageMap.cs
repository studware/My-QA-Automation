namespace SeleniumTests.Pages.Docker
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    using System.Linq;

    public partial class DockerPage
    {
        public IWebElement DotNETCoreGuide => Driver.FindElement(By.XPath(@"//*[@id='filterResults']/ul/li[3]/a"));

        public IWebElement Docker => Driver.FindElement(By.XPath(@"//*[@id='filterResults']/ul/li[3]/ul/li[12]/span"));

        public List<IWebElement> Articles => Driver.FindElements(By
                            .XPath(@"//*[@id='filterResults']/ul/li[3]/ul/li[12]/ul/li/a")).ToList();

        public IWebElement Navigation => Driver.FindElement(By.XPath(@"//*[@id='center-doc-outline']/h3"));

        public List<IWebElement> NavigationLinks => Navigation.FindElements(By.TagName("a")).ToList();

        public List<string> NavLinksToHeaderTwo => Navigation
            .FindElements(By.XPath(@"//*[@id='center-doc-outline']/ol/li/a"))
            .Select(h => h.Text)
            .ToList();

        public IWebElement Content => Driver.FindElement(By.Id("main"));

        public List<string> HeadersTwo => Content
            .FindElements(By.TagName("h2"))
            .Select(h => h.Text)
            .ToList();
    }
}

/* public List<IWebElement> Articles => Driver.FindElements(By
            .CssSelector(@"#filterResults>ul>li.selectedHolder>ul>li:nth-child(12)>ul>li>a").ToList(); */
//*[@id="center-doc-outline"]/ol/li[1]/a