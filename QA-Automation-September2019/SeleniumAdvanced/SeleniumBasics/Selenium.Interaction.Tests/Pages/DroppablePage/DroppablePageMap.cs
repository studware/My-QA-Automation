namespace Selenium.Interaction.Tests.Pages
{
	using OpenQA.Selenium;

	public partial class DroppablePage
    {
        public IWebElement DroppableLink => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[1]/ul/li[4]/a"));

        public IWebElement Draggable => Driver.FindElement(By.XPath(@"//*[@id='draggable']/p"));

        public IWebElement Droppable => Driver.FindElement(By.Id("droppable"));

        public string DroppableBackgroundColor => Droppable.GetCssValue("background-color");

        public string DroppableTextColor => Droppable.GetCssValue("color");
    }
}
