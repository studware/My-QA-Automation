namespace SeleniumTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using Pages.AccordionPage;
    using Pages.ResizablePage;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class AccordionTests : BaseTest
    {
        private AccordionPage accordion;


        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        public void Only_SectionOne_IsVisibleToTheUser()
        {
            //Arrange
            var accordion = new AccordionPage(_driver);

            //Act
            accordion.AccordionPageLink.Click();
            DelayForVideo();

            accordion.SectionOne.Click();
            DelayForVideo();
            var sectionOneExpandStatus = accordion.SectionOne.GetAttribute("aria-expanded");
            var sectionTwoExpandStatus = accordion.SectionTwo.GetAttribute("aria-expanded");
            var sectionThreeExpandStatus = accordion.SectionThree.GetAttribute("aria-expanded");
            var sectionFourthExpandStatus = accordion.SectionFourth.GetAttribute("aria-expanded");

            //Assert
            sectionOneExpandStatus.Should().Be("true");
            sectionTwoExpandStatus.Should().Be("false");
            sectionThreeExpandStatus.Should().Be("false");
            sectionFourthExpandStatus.Should().Be("false");
        }

        [Test]
        public void Only_SectionTwo_IsVisibleToTheUser()
        {
            _driver.Navigate().GoToUrl("http://demoqa.com/");
            //Arrange
            var accordion = new AccordionPage(_driver);

            //Act
            accordion.AccordionPageLink.Click();
            DelayForVideo();

            accordion.SectionTwo.Click();
            DelayForVideo();

            var sectionOneExpandStatus = accordion.SectionOne.GetAttribute("aria-expanded");
            var sectionTwoExpandStatus = accordion.SectionTwo.GetAttribute("aria-expanded");
            var sectionThreeExpandStatus = accordion.SectionThree.GetAttribute("aria-expanded");
            var sectionFourthExpandStatus = accordion.SectionFourth.GetAttribute("aria-expanded");

            //Assert
            sectionOneExpandStatus.Should().Be("false");
            sectionTwoExpandStatus.Should().Be("true");
            sectionThreeExpandStatus.Should().Be("false");
            sectionFourthExpandStatus.Should().Be("false");
        }

        [Test]
        public void Only_SectionThree_IsVisibleToTheUser()
        {
            //Arrange
            var accordion = new AccordionPage(_driver);

            //Act
            accordion.AccordionPageLink.Click();
            DelayForVideo();

            accordion.SectionThree.Click();
            DelayForVideo();

            var sectionOneExpandStatus = accordion.SectionOne.GetAttribute("aria-expanded");
            var sectionTwoExpandStatus = accordion.SectionTwo.GetAttribute("aria-expanded");
            var sectionThreeExpandStatus = accordion.SectionThree.GetAttribute("aria-expanded");
            var sectionFourthExpandStatus = accordion.SectionFourth.GetAttribute("aria-expanded");

            //Assert
            sectionOneExpandStatus.Should().Be("false");
            sectionTwoExpandStatus.Should().Be("false");
            sectionThreeExpandStatus.Should().Be("true");
            sectionFourthExpandStatus.Should().Be("false");
        }

        [Test]
        public void Only_SectionFourth_IsVisibleToTheUser()
        {
            //Arrange
            var accordion = new AccordionPage(_driver);

            //Act
            accordion.AccordionPageLink.Click();
            DelayForVideo();

            accordion.SectionFourth.Click();
            DelayForVideo();

            var sectionOneExpandStatus = accordion.SectionOne.GetAttribute("aria-expanded");
            var sectionTwoExpandStatus = accordion.SectionTwo.GetAttribute("aria-expanded");
            var sectionThreeExpandStatus = accordion.SectionThree.GetAttribute("aria-expanded");
            var sectionFourthExpandStatus = accordion.SectionFourth.GetAttribute("aria-expanded");

            //Assert
            sectionOneExpandStatus.Should().Be("false");
            sectionTwoExpandStatus.Should().Be("false");
            sectionThreeExpandStatus.Should().Be("false");
            sectionFourthExpandStatus.Should().Be("true");
        }
    }
}
