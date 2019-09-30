namespace Selenium.Interaction.Tests.Pages.ATP
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    using System.Linq;

    public partial class ATP_Page
    {
        public IWebElement Blog => Driver.FindElement(By.Id("menu-item-6"));

        public List<IWebElement> Articles => Driver.FindElements(By.TagName("Article")).ToList();

        public IWebElement Navigation => Driver.FindElement(By
            .CssSelector(@"#tve_editor > div.thrv_wrapper.thrv_contents_table.tve_ct.tve_clearfix.tve_update_contents_table.tve_green"));

        public List<IWebElement> NavigationLinks => Navigation.FindElements(By.TagName("a")).ToList();

        public List<string> NavLinksToHeaderTwo => Navigation
            .FindElements(By.ClassName("tve_ct_level0"))
            .ToList()
            .FindAll(t => t.Text != "") //
            .Select(h => h.Text)
            .ToList();

        public List<string> NavLinksToHeaderThree => Navigation
            .FindElements(By.ClassName("tve_ct_level1"))
            .ToList()
            .FindAll(t => t.Text != "") //
            .Select(h => h.Text)
            .ToList();

        public IWebElement Content => Driver.FindElement(By.Id("tve_editor"));

        public List<string> HeadersTwo => Driver
            .FindElements(By.TagName("h2"))
            .ToList()
            .FindAll(t => t.Text != "")
            .Select(h => h.Text)
            .ToList();

        public List<string> HeadersThree => Driver
            .FindElements(By.TagName("h3"))
            .ToList()
            .FindAll(t => t.Text != "")
            .Select(h => h.Text)
            .ToList();
    }
}
