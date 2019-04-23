namespace SeleniumTests.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DatePickerPage
    {
        public IWebElement DatePickerLink => Driver.FindElement(By.XPath(@"//*[@id='sidebar']/aside[2]/ul/li[9]/a"));

        public IWebElement DatePicker => Driver.FindElement(By.Id("datepicker"));

        public string Month => Driver.FindElement(By.ClassName("ui-datepicker-month")).Text;

        public string Year => Driver.FindElement(By.ClassName("ui-datepicker-year")).Text;

        public IWebElement PreviousMonth => Driver.FindElement(By.XPath(@"//*[@id='ui-datepicker-div']/div/a[1]"));

        public IWebElement NextMonth => Driver.FindElement(By.XPath(@"//*[@id='ui-datepicker-div']/div/a[2]"));

        public IWebElement TableOfDays => Driver.FindElement(By.TagName("table"));

        public List<IWebElement> LinksToDays => TableOfDays.FindElements(By.TagName("a")).ToList();
    }
}


//        public IWebElement Month => Driver.FindElement(By.XPath(@"//*[@id='ui-datepicker-div']/div/div/span[1]"));
//        public IWebElement Month => Driver.FindElement(By.XPath(@"//*[@id='ui-datepicker-div']/div/div/span[1]"));
//        public IWebElement Year => Driver.FindElement(By.XPath(@"//*[@id='ui-datepicker-div']/div/div/span[2]"));