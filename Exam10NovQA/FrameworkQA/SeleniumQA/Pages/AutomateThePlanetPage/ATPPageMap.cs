namespace SeleniumQA.Pages.AutomateThePlanetPage
{
	using System.Collections.Generic;
	using System.Linq;
	using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using SeleniumExtras.WaitHelpers;

    public partial class ATPPage
    {
	    public IWebElement Blog => Driver.FindElement(By.Id("menu-item-6"));
        public List<IWebElement> PostLists => Driver.FindElements(By.ClassName("post-list")).ToList();
        public List<IWebElement> PostsInList => PostLists[listIndex].FindElements(By.TagName("article")).ToList();
        public IWebElement Navigation => Driver.FindElement(By.XPath("//*[@id='tve_editor']")).FindElement(By.TagName("span"));
        public List<IWebElement> NavigationLinks => Driver.FindElements(By.XPath("//*[@id='tve_editor']/div[2]/div/div/a")).ToList();

        public List<string> NavLinksToHeaderTwo => Navigation
		    .FindElements(By.ClassName("tve_ct_level0"))
		    .ToList()
		    .Select(h => h.Text)
		    .ToList();

	    public List<string> NavLinksToHeaderThree => Navigation
		    .FindElements(By.ClassName("tve_ct_level1"))
		    .ToList()
		    .Select(h => h.Text)
		    .ToList();

	    public List<string> HeadersTwo => Navigation
		    .FindElements(By.TagName("h2"))     
            .ToList()
		    .FindAll(t => t.Text != "")
		    .Select(h => h.Text.Trim())
		    .ToList();

	    public List<string> HeadersThree => Navigation      
            .FindElements(By.TagName("h3"))
		    .ToList()
		    .FindAll(t => t.Text != "")
		    .Select(h => h.Text.Trim())
		    .ToList();
    }
}
