namespace SeleniumQA
{
    using System;
    using System.IO;
	using System.Reflection;
	using SeleniumQA.Pages;
	using SeleniumQA.Utilities;
	using FluentAssertions;
	using NUnit.Framework;
	using NUnit.Framework.Interfaces;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Chrome;

	[TestFixture]
	public class T1Tooltip : BaseTest
    {
		[SetUp]
	    public void SetUp()
	    {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
		    Driver.Manage().Window.Maximize();
		    Driver.Url = "http://demoqa.com/";
	    }
        
	    [Test]
		public void VerifyTooltipText()
	    {
		    var tooltipPage = new TooltipPage(Driver);
            string expectedResult = "We ask for your age only for statistical purposes.";

			tooltipPage.TooltipButton.Click();
            DelayForVideo();
			tooltipPage.AgeInput.Hover(Driver);
            DelayForVideo(3);
            string text = tooltipPage.AgeInput.GetAttribute("aria-describedby");

            tooltipPage.Tooltip(text).Text.Should().Be(expectedResult);
	    }
    }
}
