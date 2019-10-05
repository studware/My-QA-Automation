namespace Selenium.Interaction.Tests
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
            _driver.Quit();
        }

        public void DelayForVideo(int seconds = 2)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
