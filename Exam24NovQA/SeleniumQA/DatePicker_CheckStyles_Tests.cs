namespace SeleniumQA
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using SeleniumQA.Pages;
    using SeleniumQA.Utilities;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class DatePicker_CheckStyles_Tests : BaseTest
    {
        private Actions _action;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://demoqa.com/");
            _action = new Actions(Driver);
        }

        [Test]
        public void Current_Day_Styles_Should_Match_Conditions()
        {
            //Arrange
            var datePickerPage = new DatePickerPage(Driver);
            int dayToPickIndex = DateTime.Now.Day;
            int i = dayToPickIndex - 1;

            //Act
            datePickerPage.DatePickerLink.Click();

            _action.MoveToElement(datePickerPage.DatePicker).Perform();
            datePickerPage.DatePicker.Click();
            DelayForVideo();

            IWebElement[] days = datePickerPage.LinksToDays.ToArray();

            string[] actualDaysStyles = datePickerPage.FormatDaysStyles(i, days);

            //Assert
            actualDaysStyles[0].Should().BeEquivalentTo("fffa90");
            actualDaysStyles[1].Should().BeEquivalentTo("777620");
            actualDaysStyles[2].Should().BeEquivalentTo("1px solid dad55e");
        }

        [Test]
        public void Every_Days_Styles_Except_Todays_Should_Match_Conditions()
        {
            //Arrange
            var datePickerPage = new DatePickerPage(Driver);
            int dayToPickIndex = DateTime.Now.Day;

            //Act
            datePickerPage.DatePickerLink.Click();

            _action.MoveToElement(datePickerPage.DatePicker).Perform();
            datePickerPage.DatePicker.Click();
            DelayForVideo();

            IWebElement[] days = datePickerPage.LinksToDays.ToArray();

            for (int j = 0; j < dayToPickIndex - 2; j++)
            {
                string[] actualDaysStyles = datePickerPage.FormatDaysStyles(j, days);

                //Assert
                actualDaysStyles[0].Should().BeEquivalentTo("f6f6f6");
                actualDaysStyles[1].Should().BeEquivalentTo("454545");
                actualDaysStyles[2].Should().BeEquivalentTo("1px solid c5c513");
            }

            //  Step over today
            for (int j = dayToPickIndex; j < days.Length - 1; j++)
            {
                string[] actualDaysStyles = datePickerPage.FormatDaysStyles(j, days);

                //Assert
                actualDaysStyles[0].Should().BeEquivalentTo("f6f6f6");
                actualDaysStyles[1].Should().BeEquivalentTo("454545");
                actualDaysStyles[2].Should().BeEquivalentTo("1px solid c5c513");
            }
        }

        [Test]
        public void Styles_Of_Hovered_Day_Except_Today_Should_Match_Conditions()
        {
            //Arrange
            var datePickerPage = new DatePickerPage(Driver);
            int dayToPickIndex = DateTime.Now.Day;

            //Act
            datePickerPage.DatePickerLink.Click();

            _action.MoveToElement(datePickerPage.DatePicker).Perform();
            datePickerPage.DatePicker.Click();
            DelayForVideo();

            IWebElement[] days = datePickerPage.LinksToDays.ToArray();

            int j = (dayToPickIndex + 10) % days.Length;    // generate a day of month number other than today 
            days[j].Hover(Driver);
            DelayForVideo(2);

            string[] actualDaysStyles = datePickerPage.FormatDaysStyles(j, days);

            //Assert
            actualDaysStyles[0].Should().BeEquivalentTo("ededed");
            actualDaysStyles[1].Should().BeEquivalentTo("2b2b2b");
            actualDaysStyles[2].Should().BeEquivalentTo("1px solid cccc14");
        }
    }
}
//•	20 points for assert that after hover any day(except today), it has:
//o Background: ededed
//o   Color: 2b2b2b
//o   Border: 1px solid cccccc

