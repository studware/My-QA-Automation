namespace Selenium.Interaction.Tests
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
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        [TestCase (0, 1, 2, 3)]
        [TestCase (1, 0, 2, 3)]
        [TestCase (2, 1, 0, 3)]
        [TestCase (3, 1, 2, 0)]
        public void OnlyClickedSection_Should_Be_Visible(int clicked, int other1, int other2, int other3)
        {
            //Arrange
            var accordion = new AccordionPage(_driver);

            //Act
            accordion.AccordionPageLink.Click();
            DelayForVideo();

            accordion.Sections[clicked].Click();
            DelayForVideo();
            var sectionClickedExpandStatus = accordion.Sections[clicked].GetAttribute("aria-expanded");
            var sectionOther1ExpandStatus = accordion.Sections[other1].GetAttribute("aria-expanded");
            var sectionOther2ExpandStatus = accordion.Sections[other2].GetAttribute("aria-expanded");
            var sectionOther3ExpandStatus = accordion.Sections[other3].GetAttribute("aria-expanded");

            //Assert
            sectionClickedExpandStatus.Should().Be("true");
            sectionOther1ExpandStatus.Should().Be("false");
            sectionOther2ExpandStatus.Should().Be("false");
            sectionOther3ExpandStatus.Should().Be("false");
        }
    }
}
