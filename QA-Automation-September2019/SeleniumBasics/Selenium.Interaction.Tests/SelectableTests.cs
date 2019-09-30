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
    public class SelectableTests : BaseTest
    {
        private Actions _action;
        private SelectablePage selectablePage;

        internal string expectedColor = "rgba(255, 255, 255, 1)";

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _action = new Actions(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        public void Select_Item_Should_Change_In_Color()
        {
            //Arrange
            selectablePage = new SelectablePage(_driver);

            selectablePage.SelectableLink.Click();
            DelayForVideo();

            var itemToSelect = selectablePage.Selectables[2];
            _action.MoveToElement(itemToSelect).Click().Perform();
            DelayForVideo();

            //Act
            var afterColor = itemToSelect.GetCssValue("color");

            //Assert
            Assert.AreEqual(expectedColor, afterColor, "Item is not selected.");
        }

        [Test]
        public void On_Click_Item_It_Should_Become_Selected()
        {
            //Arrange
            selectablePage = new SelectablePage(_driver);

            selectablePage.SelectableLink.Click();
            DelayForVideo();

            var itemToSelect = selectablePage.Selectables[0];
            
            //Act
            _action.MoveToElement(itemToSelect).Click().Perform();
            DelayForVideo();

            //Assert
            Assert.IsNotNull(selectablePage.ItemSelected);
        }
    }
}





