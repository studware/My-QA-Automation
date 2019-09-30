namespace Selenium.Interaction.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using Selenium.Interaction.Tests.Pages;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class Draggable_DroppableTests : BaseTest
    {
        private Actions _action;
        private DroppablePage droppablePage;

        internal string expectedBGColor = "rgba(255, 250, 144, 1)";
        internal string expectedTextColor = "rgba(119, 118, 32, 1)";

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _action = new Actions(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        public void DragSliderInto_Droppable_Element_Should_Change_TextColor()
        {
            //Arrange
            droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            //Act
            droppablePage.DragAndDropHandle(droppablePage.Draggable, 140, 30);
            DelayForVideo();

            var actualTextColor = droppablePage.DroppableTextColor;

            //Assert
            actualTextColor.Should().BeEquivalentTo(expectedTextColor);

//           var textAfter = droppablePage.Draggable.Text;
//           Assert.AreEqual("Drag me around", textAfter, "Text is not Drag me around.");
        }

        [Test]
        public void DragSliderInto_Droppable_Element_Should_Change_BGColor()
        {
            //Arrange
            droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            //Act
            droppablePage.DragAndDropHandle(droppablePage.Draggable, 140, 30);
            DelayForVideo();

            var actualBGColor = droppablePage.DroppableBackgroundColor;

            //Assert
            actualBGColor.Should().BeEquivalentTo(expectedBGColor);
        }

        [Test]
        public void DragSliderOutOf_Droppable_Element_Should_Not_Change_TextColor()
        {
            //Arrange
            droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            var expectedBGColor = droppablePage.DroppableBackgroundColor;
            var expectedTextColor = droppablePage.DroppableTextColor;

            //Act
            droppablePage.DragAndDropHandle(droppablePage.Draggable, 40, 200);
            DelayForVideo();

            var actualTextColor = droppablePage.DroppableTextColor;

            //Assert
            actualTextColor.Should().BeEquivalentTo(expectedTextColor);
        }

        [Test]
        public void DragSliderOutOf_Droppable_Element_Should_Not_Change_BGColor()
        {
            //Arrange
            droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            var expectedBGColor = droppablePage.DroppableBackgroundColor;

            //Act
            droppablePage.DragAndDropHandle(droppablePage.Draggable, 40, 200);
            DelayForVideo();

            var actualBGColor = droppablePage.DroppableBackgroundColor;
            var actualTextColor = droppablePage.DroppableTextColor;

            //Assert
            actualBGColor.Should().BeEquivalentTo(expectedBGColor);
        }

        [Test]
        public void DragSlider_Right_Down_Should_Increase_X_And_Y_location()
        {
            //Arrange
            droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            var dragX = droppablePage.Draggable.Location.X;
            var dragY = droppablePage.Draggable.Location.Y;
           
            //Act
            droppablePage.DragAndDropHandle(droppablePage.Draggable, 40, 200);
            DelayForVideo();

            var afterX = droppablePage.Draggable.Location.X;
            var afterY = droppablePage.Draggable.Location.Y;

            //Assert
            afterX.Should().BeGreaterThan(dragX);
            afterY.Should().BeGreaterThan(dragY);
        }

        [Test]
        public void DragSlider_Left_Up_Should_Decrease_X_And_Y_location()
        {
            //Arrange
            droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            var dragX = droppablePage.Draggable.Location.X;
            var dragY = droppablePage.Draggable.Location.Y;

            //Act
            droppablePage.DragAndDropHandle(droppablePage.Draggable, -40, -20);
            DelayForVideo();

            var afterX = droppablePage.Draggable.Location.X;
            var afterY = droppablePage.Draggable.Location.Y;

            //Assert
            afterX.Should().BeLessThan(dragX);
            afterY.Should().BeLessThan(dragY);
        }

        [Test]
        public void DragSlider_By_Offset_Should_Change_X_And_Y_location_Correct()
        {
            //Arrange
            droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            var dragX = droppablePage.Draggable.Location.X;
            var dragY = droppablePage.Draggable.Location.Y;

            var offsetX = -20;
            var offsetY = 200;

            //Act
            droppablePage.DragAndDropHandle(droppablePage.Draggable, offsetX, offsetY);
            DelayForVideo();

            var afterX = droppablePage.Draggable.Location.X;
            var afterY = droppablePage.Draggable.Location.Y;

            //Assert
            afterX.Should().Be(dragX+offsetX);
            afterY.Should().Be(dragY+offsetY);
        }
/*
        [Test]
        public void DragOutsidePageContent()
        {
            droppablePage = new DroppablePage(_driver);

            droppablePage.DroppableLink.Click();
            DelayForVideo();

            var draggable = droppablePage.Draggable;
            _action.MoveToElement(droppablePage.Draggable).Perform();
            DelayForVideo();

            var draggableXOffset = _driver.Manage().Window.Size.Width - draggable.Location.X - draggable.Size.Width;
            droppablePage.DragAndDropHandle(droppablePage.Draggable, draggableXOffset, 0);

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            bool horizontalScroll = (bool)js.ExecuteScript("return document.documentElement.scrollWidth > document.documentElement.clientWidth;");
            Assert.IsTrue(horizontalScroll);
        }
*/
    }
}





