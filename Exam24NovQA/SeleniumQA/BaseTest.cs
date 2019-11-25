namespace SeleniumQA
{
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.IO;
    using System.Threading;
    public class BaseTest
    {
        public IWebDriver Driver { get; protected set; }
        public WebDriverWait Wait { get; protected set; }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var path = Path.GetFullPath(Directory.GetCurrentDirectory()
                                      + @"\..\..\..\Screenshots\") +
                                      TestContext.CurrentContext.Test.Name + ".png";
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            }
            Driver.Quit();
        }

        public void DelayForVideo(int seconds = 1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        //public string RgbAlphaToHex(string rgbAlpha)
        //{
        //    string str = rgbAlpha.Substring(rgbAlpha.IndexOf("(") + 1);
        //    string[] numbers = str.Replace(")", "").Split(",");
        //    string number1 = Convert.ToString(int.Parse(numbers[0]), 16);
        //    numbers[1] = numbers[1].Trim();
        //    string number2 = Convert.ToString(int.Parse(numbers[1]), 16);
        //    numbers[2] = numbers[2].Trim();
        //    string number3 = Convert.ToString(int.Parse(numbers[2]), 16);
        //    string colorHex = $"{number1}{number2}{number3}";
        //    return colorHex;
        //}

        //public string[] FormatDaysStyles(int i, IWebElement[] days)
        //{
        //    string[] actualDaysStyles = new string[3];

        //    actualDaysStyles[0] = RgbAlphaToHex(days[i].GetCssValue("background-color")); // actualBackGround
        //    actualDaysStyles[1] = RgbAlphaToHex(days[i].GetCssValue("color"));            // actualColor

        //    string border = days[i].GetCssValue("border");
        //    string borderColorHex = RgbAlphaToHex(border.Substring(14, 12));
        //    string borderLeftPart = border.Substring(0, 10);
        //    actualDaysStyles[2] = $"{borderLeftPart}{borderColorHex}";               // actualBorder
        //    return actualDaysStyles;
        //}
    }
}
