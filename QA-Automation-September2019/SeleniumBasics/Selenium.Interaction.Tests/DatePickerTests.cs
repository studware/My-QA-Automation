namespace Selenium.Interaction.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using Selenium.Interaction.Tests.Pages;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class DatePickerTests : BaseTest
    {
        private Actions _action;

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

            string monthInt =  datePickerPage.PickYearAndMonth(month, year).ToString().PadLeft(2, '0');


            Thread.Sleep(500);
 
            IWebElement[] days = datePickerPage.LinksToDays.ToArray();
            string actualDay = days[dayToPick - 1].Text;
            days[dayToPick-1].Click();


            Thread.Sleep(1000);
            string actualDate = datePickerPage.DatePicker.GetAttribute("value").ToString();
            //Assert
            string expectedDate = monthInt + "/" + day.ToString() +"/" +  year;


            actualDate.Should().BeEquivalentTo(expectedDate);
        }
    }
}





