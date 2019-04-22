namespace SeleniumTests.Pages
{
	using OpenQA.Selenium;

	public partial class TooltipPage
	{
        // public IWebElement TooltipLink => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[1]/a"));   
        public IWebElement TooltipLink => Driver.FindElement(By.CssSelector(@"#sidebar > aside:nth-child(2) > ul > li:nth-child(1) > a"));

		public IWebElement AgeInput => Driver.FindElement(By.Id("age"));

        //Bonus 
        //public IWebElement Tooltip => Driver.FindElement(By.XPath("/html/body/div[5]/div[1]"));
        //public IWebElement TooltipLink => Driver.FindElement(By.XPath(@"//div[@role=""tooltip""]"));

        public string TooltipId => AgeInput.GetAttribute("aria-describedby");

        public IWebElement Tooltip => Driver.FindElement(By.Id(TooltipId));

        //        public string TooltipId => AgeInput.GetAttribute("aria-describedby");
        //		public IWebElement Tooltip => Driver.FindElement(By.Id(TooltipId));
    }
}
