namespace Selenium.Interaction.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System.IO;
    using System.Reflection;
    using Pages.ResizablePage;
    using System;
    using FluentAssertions;
    using OpenQA.Selenium.Interactions;

    [TestFixture]
    public class ResizableTests : BaseTest
    {
        private ResizablePage resizable;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        public void CheckResizeBy150W150HPixels()
        {
            //Arrange
            var resizable = new ResizablePage(_driver);

            //Act
            resizable.ResizeableLink.Click();
            DelayForVideo();

            resizable.Resize(resizable.ResizeDiagonal, 150, 150);
            DelayForVideo();

//            var resized = resizable.ResizeableItem.GetAttribute("style");
            int w = resizable.ResizeableItem.Size.Width;
            int h = resizable.ResizeableItem.Size.Height;

            bool isInRange = ((w >= 282) && (w <= 284)) && ((h >= 282) && (h <= 284));

            //Assert
            Assert.IsTrue(isInRange, "The width and/or height of the resized widget out of range 283 x 283 pixels (+-1 pixel)");
        }

        [Test]
        public void Resize_With_Negative_Offset_Should_Shrink_The_Resizable_Widjet()
        {
            //Arrange
            var resizable = new ResizablePage(_driver);

            //Act
            resizable.ResizeableLink.Click();
            DelayForVideo();

            int initialWidth = resizable.ResizeableItem.Size.Width;
            int initialHeight = resizable.ResizeableItem.Size.Height;
            resizable.Resize(resizable.ResizeDiagonal, -50, -100);
            DelayForVideo();

            int w = resizable.ResizeableItem.Size.Width;
            int h = resizable.ResizeableItem.Size.Height;
            bool isShrinked = (w < initialWidth && h < initialHeight);

            //Assert
            Assert.IsTrue(isShrinked, "The resized widget doesn't srink when the X and/or Y offset is negative!");
        }
    }
}