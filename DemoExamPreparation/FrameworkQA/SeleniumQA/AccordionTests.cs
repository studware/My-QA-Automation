namespace SeleniumQA
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using Pages.AccordionPage;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class AccordionTests : BaseTest
    {
        private AccordionPage accordion;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        public void Only_SectionOne_IsVisibleToTheUser()
        {
            //Arrange
            accordion = new AccordionPage(Driver);

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
            //Arrange
            accordion = new AccordionPage(Driver);

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
            accordion = new AccordionPage(Driver);

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
        public void Only_SectionFour_IsVisibleToTheUser()
        {
            //Arrange
            accordion = new AccordionPage(Driver);

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
