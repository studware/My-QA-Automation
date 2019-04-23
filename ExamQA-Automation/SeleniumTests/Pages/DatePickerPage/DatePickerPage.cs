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

        public string[] PickYearAndMonth(string month, string year)
        {
            _action = new Actions(Driver);

            int currentMonth = Array.FindIndex(yearMonths, row => row.Contains(Month)) + 1;  // current month index
            int currentYear = Convert.ToInt32(Year);
            
            int targetMonth = Array.FindIndex(yearMonths, row => row.Contains(month)) + 1;  //  target month index
            int targetYear = Convert.ToInt32(year);

            int yearDiff = targetYear - currentYear;
            int monthsToScroll = yearDiff * 12 + targetMonth - currentMonth;

            if (monthsToScroll > 0)
            {
                _action.MoveToElement(NextMonth).Perform();
             
                while (monthsToScroll > 0)
                {
                    NextMonth.Click();
                    monthsToScroll--;
                    currentMonth++;
                    Thread.Sleep(1000);
                }
                currentMonth = currentMonth%12;
            }
            else if (monthsToScroll < 0)
            {
                monthsToScroll = Math.Abs(yearDiff * 12) + currentMonth - targetMonth;
                _action.MoveToElement(PreviousMonth).Perform();

                while (monthsToScroll > 0)
                {
                    PreviousMonth.Click();
                    monthsToScroll--;
                    currentMonth--;

                    if (currentMonth == 0)
                    {
                        currentMonth = 12;
                    }
                    Thread.Sleep(1000);
                }
            }
            return  new string[] { Year, currentMonth.ToString().PadLeft(2, '0'), year, targetMonth.ToString().PadLeft(2, '0' )};
        }
    }
}

