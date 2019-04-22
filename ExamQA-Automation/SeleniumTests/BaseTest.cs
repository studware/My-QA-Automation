namespace SeleniumTests
{
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using System;
    using System.IO;
    using System.Threading;

    public class BaseTest
    {
        public IWebDriver _driver;

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                int i = TestContext.CurrentContext.Test.Name.IndexOf('(');
                var path = Path.GetFullPath(Directory.GetCurrentDirectory()
                                      + @"\..\..\..\Screenshots\") +
                                      TestContext.CurrentContext.Test.Name.Substring(0,i) + ".png";
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            }

            _driver.Quit();
        }

        public void DelayForVideo(int seconds = 2)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
