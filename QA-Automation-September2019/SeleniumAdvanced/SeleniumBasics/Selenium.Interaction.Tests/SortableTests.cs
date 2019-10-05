namespace Selenium.Interaction.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using Selenium.Interaction.Tests.Pages;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class SortableTests : BaseTest
    {
        private Actions _action;
        private SortablePage sortablePage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _action = new Actions(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        public void MoveFirstToThirdElement()
        {
            //Arrange
            sortablePage = new SortablePage(_driver);

            sortablePage.SortableLink.Click();
            DelayForVideo();

            var sortableElements = sortablePage.Sortables;
            var initialPositionItem1Y = sortableElements[0].Location.Y;
            var initialPositionItem2Y = sortableElements[1].Location.Y;
            var initialPositionItem3Y = sortableElements[2].Location.Y;

            sortablePage.DragAndDropElement(sortableElements[0], 0, initialPositionItem3Y - initialPositionItem1Y + 1);  //move first element on the place of 3rd 
            DelayForVideo();

            var realPositionItem1Y = sortableElements[0].Location.Y;
            var realPositionItem2Y = sortableElements[1].Location.Y;
            var realPositionItem3Y = sortableElements[2].Location.Y;

            Assert.AreEqual(initialPositionItem3Y, realPositionItem1Y, "Position Y of Item 1 "); //The 1st became 3rd
            Assert.AreEqual(initialPositionItem1Y, realPositionItem2Y, "Position Y of Item 2 "); //The 2nd became 1st
            Assert.AreEqual(initialPositionItem2Y, realPositionItem3Y, "Position Y of Item 3 "); //The 3rd became 2nd
        }

        [Test]
        public void MoveFromDownToUp()
        {
            //Arrange
            sortablePage = new SortablePage(_driver);

            sortablePage.SortableLink.Click();
            DelayForVideo();

            var sortableElements = sortablePage.Sortables;
            int initialPositionItem6Y = sortableElements[5].Location.Y;
            int initialPositionItem7Y = sortableElements[6].Location.Y;
            sortablePage.DragAndDropElement(sortableElements[6], 0, initialPositionItem6Y - initialPositionItem7Y);
            Assert.AreEqual(initialPositionItem6Y, sortableElements[6].Location.Y);
            Assert.AreEqual(initialPositionItem7Y, sortableElements[5].Location.Y);
        }
    }
}





