namespace Selenium.Interaction.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using Selenium.Interaction.Tests.Pages;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
	public class TooltipTest : BaseTest
    {
        private Actions _action;

        [SetUp]
	    public void SetUp()
	    {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _action = new Actions(_driver);
		    _driver.Manage().Window.Maximize();
		    _driver.Navigate().GoToUrl("http://demoqa.com/");
	    }
        
	    [Test]
		public void VerifyTooltipText()
	    {
            var tooltipPage = new TooltipPage(_driver);

            tooltipPage.TooltipLink.Click();

            _action = new Actions(_driver);
            _action.MoveToElement(tooltipPage.AgeInput).Perform();

//            Thread.Sleep(1000);
            string expectedResult = "We ask for your age only for statistical purposes.";
            tooltipPage.Tooltip.Text.Should().Be(expectedResult);
	    }
    }
}
