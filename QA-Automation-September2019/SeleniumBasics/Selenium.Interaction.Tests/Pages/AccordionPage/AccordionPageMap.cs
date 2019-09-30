namespace Selenium.Interaction.Tests.Pages.AccordionPage
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class AccordionPage
    {
        public IWebElement AccordionPageLink => Wait.Until(d => { return d.FindElement(By.XPath("//a[contains(text(),'Accordion')]")); });

        public IWebElement Accordion => Driver.FindElement(By.Id("accordion"));

        public List<IWebElement> Sections => Accordion.FindElements(By.TagName("h3")).ToList();
    }
}