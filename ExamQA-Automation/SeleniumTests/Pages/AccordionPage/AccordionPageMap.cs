namespace SeleniumTests.Pages.AccordionPage
{
    using OpenQA.Selenium;

    public partial class AccordionPage
    {
        public IWebElement AccordionPageLink => Wait.Until(d => { return d.FindElement(By.XPath("//a[contains(text(),'Accordion')]")); });

        public IWebElement SectionOne => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-1']")); });

        public IWebElement SectionTwo => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-3']")); });

        public IWebElement SectionThree => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-5']")); });

        public IWebElement SectionFourth => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-7']")); });
    }
}
