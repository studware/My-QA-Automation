namespace Selenium.Interaction.Tests.Pages
{
	using OpenQA.Selenium;

	public partial class SliderPage
    {
        public IWebElement SliderLink => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[4]/a"));

        public IWebElement SliderInput => Driver.FindElement(By.Id("slider"));

        // public IWebElement SliderLink => Driver.FindElement(By.CssSelector(@"#sidebar>aside:nth-child(2)>ul>li:nth-child(4)>a"));
        //public IWebElement SliderInput => Driver.FindElement(By.XPath("//*[@id='slider']"));

        public IWebElement SliderHandle => Driver.FindElement(By.XPath(@"//*[@id='slider']/span"));

        public string SliderInputValue => SliderHandle.GetAttribute("style");
    }
}
