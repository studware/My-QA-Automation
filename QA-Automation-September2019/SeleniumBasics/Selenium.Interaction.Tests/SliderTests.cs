namespace Selenium.Interaction.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using Selenium.Interaction.Tests.Pages;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
	public class SliderTests : BaseTest
    {
        private Actions _action;
        private SliderPage slider;

        [SetUp]
	    public void SetUp()
	    {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _action = new Actions(_driver);
		    _driver.Manage().Window.Maximize();
		    _driver.Navigate().GoToUrl("http://demoqa.com/");
	    }
        
	    [Test]
        [TestCase (-170)]
        [TestCase (-135)]
        [TestCase (-97)]
        [TestCase (-59)]
        [TestCase (-21)]
        [TestCase (17)]
        [TestCase (55)]
        [TestCase (93)]
        [TestCase (131)]
        [TestCase (170)]
		public void DragSliderToRight_Should_IncreaseInputValue(int offsetToRight)
	    {
            //Arrange
            var slider = new SliderPage(_driver);

            slider.SliderLink.Click();
            DelayForVideo();

            _action = new Actions(_driver);
            _action.MoveToElement(slider.SliderInput).Perform();
            DelayForVideo();

            var valueBefore = slider.SliderHandle.GetAttribute("style").Split(' ');
            int percentsBefore = Convert.ToInt32(valueBefore[1].Substring(0, valueBefore[1].Length - 2));

            //Act
            slider.MoveSliderHandle(slider.SliderHandle, offsetToRight, 0);
            DelayForVideo();

            var valueAfter = slider.SliderHandle.GetAttribute("style").Split(' ');
            int percentsAfter = Convert.ToInt32(valueAfter[1].Substring(0, valueAfter[1].Length - 2));

            //Assert
            Assert.That(percentsBefore < percentsAfter, "On slider drag to right the input over it decreases its value!");
        }
    }
}
       
