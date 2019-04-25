namespace SeleniumTests.Pages
{
	using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System;
    using System.Threading;

    public partial class DatePickerPage : BasePage
    {
        private Actions _action;

        public DatePickerPage(IWebDriver driver) : base(driver)
	    {
	    }

        private string[] yearMonths = new string[12] {
                                "January", "February", "March",
                                "April", "May", "June",
                                "July", "August", "September",
                                "October", "November", "December"};

        public int PickYearAndMonth(string month, string year)
        {
            _action = new Actions(Driver);

            int currentMonth = Array.FindIndex(yearMonths, row => row.Contains(Month)) + 1;
            int currentYear = Convert.ToInt32(Year);
            
            int monthToPick = Array.FindIndex(yearMonths, row => row.Contains(month)) + 1;
            int yearToPick = Convert.ToInt32(year);

            int monthsToScroll = (yearToPick - currentYear) * 12 + monthToPick - currentMonth;

            if (monthsToScroll > 0)
            {
                _action.MoveToElement(NextMonth).Perform();
             
                while (monthsToScroll > 0)
                {
                    NextMonth.Click();
                    monthsToScroll--;
                    Thread.Sleep(1000);
                }
            }
            else if (monthsToScroll < 0)
            {
                _action.MoveToElement(PreviousMonth).Perform();

                while (monthsToScroll < 0)
                {
                    PreviousMonth.Click();
                    monthsToScroll++;
                    Thread.Sleep(500);
                }
            }

            return monthToPick;
        }
    }
}

