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
        private AccordionPage _accordion;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        [TestCase (1, 2, 3, 0)]
        [TestCase (2, 3, 0, 1)]
        [TestCase (3, 0, 1, 2)]
        [TestCase (0, 1, 2, 3)]
        public void Only_Selected_Section_Is_Visible_ToTheUser(int selected, int unselected1, 
                                                            int unselected2, int unselected3)
        {
            //Arrange
            _accordion = new AccordionPage(Driver);

            //Act
            _accordion.AccordionPageLink.Click();
            DelayForVideo();

            //IWebElement[] sections = new IWebElement[] {
            //    _accordion.SectionOne,
            //    _accordion.SectionTwo,
            //    _accordion.SectionThree,
            //    _accordion.SectionFour
            //};

            _accordion.Sections[selected].Click();
            DelayForVideo();

            //Assert
            _accordion.Sections[selected].GetAttribute("aria-expanded").Should().Be("true");
            _accordion.Sections[unselected1].GetAttribute("aria-expanded").Should().Be("false");
            _accordion.Sections[unselected2].GetAttribute("aria-expanded").Should().Be("false");
            _accordion.Sections[unselected3].GetAttribute("aria-expanded").Should().Be("false");
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(0)]
        public void All_Sections_Have_Arrow_Displayed_Before_Name(
                                                    int selected)
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/");
            //Arrange
            _accordion = new AccordionPage(Driver);

            //Act
            _accordion.AccordionPageLink.Click();
            DelayForVideo();

            //IWebElement[] sections = new IWebElement[] {
            //    _accordion.SectionOne,
            //    _accordion.SectionTwo,
            //    _accordion.SectionThree,
            //    _accordion.SectionFour
            //};

            _accordion.Sections[selected].Click();
            DelayForVideo();

            bool sectionOneArrow = _accordion.ArrowSectionOne.Displayed;
            bool sectionTwoArrow = _accordion.ArrowSectionTwo.Displayed;
            bool sectionThreeArrow = _accordion.ArrowSectionThree.Displayed;
            bool sectionFourArrow = _accordion.ArrowSectionFour.Displayed;

            //Assert
            sectionOneArrow.Should().Be(true);
            sectionTwoArrow.Should().Be(true);
            sectionThreeArrow.Should().Be(true);
            sectionFourArrow.Should().Be(true);
        }
    }
}
