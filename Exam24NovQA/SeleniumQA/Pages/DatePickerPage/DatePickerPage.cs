﻿namespace SeleniumQA.Pages
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

        private readonly string[] yearMonths = new string[12] {
                                "January", "February", "March",
                                "April", "May", "June",
                                "July", "August", "September",
                                "October", "November", "December"};

        public string[] PickYearAndMonth(string month, string year)
        {
            _action = new Actions(Driver);

            int currentMonth = Array.FindIndex(yearMonths, row => row.Contains(Month)) + 1;
            int currentYear = Convert.ToInt32(Year);

            int monthToPick = Array.FindIndex(yearMonths, row => row.Contains(month)) + 1;
            int yearToPick = Convert.ToInt32(year);

            int yearDiff = yearToPick - currentYear;
            int monthsToScroll = yearDiff * 12 + monthToPick - currentMonth;

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
                monthsToScroll = yearDiff * 12 + currentMonth - monthToPick;
                _action.MoveToElement(PreviousMonth).Perform();

                while (monthsToScroll > 0)
                {
                    PreviousMonth.Click();
                    monthsToScroll--;
                    Thread.Sleep(1000);
                }
            }

            return new string[] { Year, currentMonth.ToString().PadLeft(2, '0'), year, monthToPick.ToString().PadLeft(2, '0') };
        }
    }
}

