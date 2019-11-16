namespace SeleniumQA.Pages.AccordionPage
{
    using OpenQA.Selenium;

    public partial class AccordionPage
    {
        public IWebElement AccordionPageLink => Wait.Until(d => { return d.FindElement(By.XPath("//a[contains(text(),'Accordion')]")); });

        public IWebElement ArrowSelected => Wait.Until(d => { return d.FindElement(By.XPath("//div[@class='ui-accordion-header-icon ui-icon ui-icon-triangle-1-s']")); });

        public IWebElement ArrowUnSelected => Wait.Until(d => { return d.FindElement(By.XPath("//div[@class='ui-accordion-header-icon ui-icon ui-icon-triangle-1-e']")); });

        public IWebElement SectionOne => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-1']")); });  // <span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-s"></span>

        public IWebElement SectionTwo => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-3']")); });

        public IWebElement SectionThree => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-5']")); });

        public IWebElement SectionFourth => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-7']")); });
    }
}
