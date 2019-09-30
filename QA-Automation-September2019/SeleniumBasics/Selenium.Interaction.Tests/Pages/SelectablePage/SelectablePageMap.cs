namespace Selenium.Interaction.Tests.Pages
{
	using OpenQA.Selenium;
    using System.Collections.Generic;

    public partial class SelectablePage
    {
        public IWebElement SelectableLink => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[1]/ul/li[2]/a"));
 
        public IList<IWebElement> Selectables => Driver.FindElements(By.XPath(@"//*[@id='selectable']/li"));

        public IWebElement ItemSelected => Driver.FindElement(By.XPath("//*[@id='selectable']/li[contains(@class, 'ui-widget-content ui-selectee ui-selected')]"));
    }
}
