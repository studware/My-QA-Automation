using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Extensions
{
    public static class ElementExtension
    {
        public static void Type(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }
    }
}
