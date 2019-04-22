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
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class DatePickerTests : BaseTest
    {
        private Actions _action;
        private DatePickerPage datePickerPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _action = new Actions(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demoqa.com/");
        }

        [Test]
        [TestCase("April", 21, "2019")]
        [TestCase("April", 22, "2019")]
        [TestCase("April", 23, "2019")]
        public void Textbox_Value_Should_Match_Selected_Date(string month, int day, string year)
        {
            //Arrange
            var datePickerPage = new DatePickerPage(_driver);
            int dayToPick = day;

            //Act
            datePickerPage.DatePickerLink.Click();

            _action.MoveToElement(datePickerPage.DatePicker).Perform();
            datePickerPage.DatePicker.Click();

            string[] yearMonth =  datePickerPage.PickYearAndMonth(month, year);

            DelayForVideo();
 
            IWebElement[] days = datePickerPage.LinksToDays.ToArray();
            string actualDay = days[dayToPick - 1].Text;
            days[dayToPick-1].Click();
            Thread.Sleep(2000);

            //Assert

            string actualDate = yearMonth[1] + "/" + actualDay + "/" + yearMonth[0].ToString();
            string expectedDate = yearMonth[3] + "/" + day.ToString() +"/" +  yearMonth[2];

            actualDate.Should().BeEquivalentTo(expectedDate);
        }
    }
}





