namespace Selenium.Interaction.Tests.Pages
{
	using OpenQA.Selenium;
    using System.Collections.Generic;

    public partial class SortablePage
    {
        public IWebElement SortableLink => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[1]/ul/li[1]/a"));

        public IList<IWebElement> Sortables => Driver.FindElements(By.XPath(@"//*[@id='sortable']/li"));
    }
}
