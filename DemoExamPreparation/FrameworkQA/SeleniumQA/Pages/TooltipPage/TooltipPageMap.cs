namespace SeleniumQA.Pages
{
	using OpenQA.Selenium;

	public partial class TooltipPage
	{
        ////*[@id="sidebar"]/aside[2]/ul/li[1]/a
        public IWebElement TooltipButton => Driver.FindElement(By.CssSelector(@"#sidebar > aside:nth-child(2) > ul > li:nth-child(6) > a"));

        public IWebElement AgeInput => Driver.FindElement(By.Id("age"));

		//Bonus 
		//public IWebElement Tooltip => Driver.FindElement(By.XPath("/html/body/div[5]/div[1]"));
		//public IWebElement TooltipLink => Driver.FindElement(By.XPath(@"//div[@role=""tooltip""]"));

		public IWebElement Tooltip(string id)
		{
			return Wait.Until(d => Driver.FindElement(By.Id(id)));
		}
	}
}
