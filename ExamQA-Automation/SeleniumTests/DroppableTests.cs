namespace SeleniumTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using SeleniumTests.Pages;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class DroppableTests : BaseTest
    {
        private Actions _action;
        private DroppablePage droppablePage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _action = new Actions(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        public void DragSliderInto_Droppable_Element_Should_Change_BGColor_And_TextColor()
        {
            //Arrange
            string expectedBGColor = "rgba(255, 250, 144, 1)";
            string expectedTextColor = "rgba(119, 118, 32, 1)";

            var droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            //Act
            droppablePage.DragAndDropHandle(droppablePage.Draggable, 140, 30);
            DelayForVideo();

            var actualBGColor = droppablePage.DroppableBackgroundColor;
            var actualTextColor = droppablePage.DroppableTextColor;

            //Assert
            actualBGColor.Should().BeEquivalentTo(expectedBGColor);
            actualTextColor.Should().BeEquivalentTo(expectedTextColor);
        }

        [Test]
        public void DragSliderOutOf_Droppable_Element_Should_Not_Change_BGColor_And_TextColor()
        {
            //Arrange
            var droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            var expectedBGColor = droppablePage.DroppableBackgroundColor;
            var expectedTextColor = droppablePage.DroppableTextColor;

            //Act
            droppablePage.DragAndDropHandle(droppablePage.Draggable, 40, 200);
            DelayForVideo();

            var actualBGColor = droppablePage.DroppableBackgroundColor;
            var actualTextColor = droppablePage.DroppableTextColor;

            //Assert
            actualBGColor.Should().BeEquivalentTo(expectedBGColor);
            actualTextColor.Should().BeEquivalentTo(expectedTextColor);
        }
    }
}





