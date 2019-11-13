namespace SeleniumQA.Pages.AccordionPage
{
    using OpenQA.Selenium;

    public partial class AccordionPage
    {
        public IWebElement AccordionPageLink => Wait.Until(d => {
            return d.FindElement(By.XPath("//a[contains(text(),'Accordion')]")); });

        public IWebElement SectionOne => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-1']")); });
        public IWebElement ArrowSectionOne => SectionOne.FindElement(By.TagName("span"));

        public IWebElement SectionTwo => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-3']")); });
        public IWebElement ArrowSectionTwo => SectionTwo.FindElement(By.TagName("span"));

        public IWebElement SectionThree => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-5']")); });
        public IWebElement ArrowSectionThree => SectionThree.FindElement(By.TagName("span"));

        public IWebElement SectionFour => Wait.Until(d => { return d.FindElement(By.XPath("//h3[@id='ui-id-7']")); });
        public IWebElement ArrowSectionFour => SectionFour.FindElement(By.TagName("span"));

        public IWebElement[] Sections
        {
            get
            {
                return new IWebElement[] { SectionOne, SectionTwo, SectionThree, SectionFour };
            }
        }
    }
}

//public IWebElement ArrowSectionOne => Wait.Until(d => {
//    return d.FindElement(By.XPath("//h3[@id='ui-id-1']/span")); });
//  /html/body/div[1]/div[2]/div/div[2]/div[2]/div/h3[2]/span

//public List<IWebElement> NavigationLinks => Navigation.FindElements(By.TagName("a")).ToList();

//public List<string> NavLinksToHeaderTwo => Navigation
//    .FindElements(By.ClassName("tve_ct_level0"))
//    .ToList()
//    .FindAll(t => t.Text != "") //
//    .Select(h => h.Text)
//    .ToList();
