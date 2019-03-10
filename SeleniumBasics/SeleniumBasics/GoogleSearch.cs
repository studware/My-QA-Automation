namespace SeleniumBasics
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System.Threading;

    [TestFixture]
    public class GoogleSearch: SetupTest
    {
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void GoogleSearchTest()
        {
            //Arrange&Act
            driver.Navigate().GoToUrl("https://google.com");

            IWebElement searchInput = wait.Until<IWebElement>(si => 
                            { return si.FindElement(
                                By.XPath("//*[@id='tsf']/div[2]/div/div[1]/div/div[1]/input")); });
            searchInput.SendKeys("Selenium");
            string searchValue = searchInput.GetAttribute("value");

            //Assert
            Assert.IsNotNull(searchValue);
            Assert.AreEqual("Selenium", searchValue);

            //Arrange&Act
            driver.FindElement(By.TagName("center")).Click();

            Thread.Sleep(2000);

            IWebElement firstLink = wait.Until<IWebElement>(fl => 
                            { return fl.FindElement(
                            By.XPath("//*[@id='rso']/div/div/div[1]/div/div/div[1]/a[1]")); });

            string firstLinkText = firstLink.Text;
            firstLink.Click();

            //Assert
            Assert.That(firstLinkText.Contains("Selenium - Web Browser Automation"));
            string url = driver.Url;
            Assert.IsNotNull(url);
            Assert.AreEqual("https://www.seleniumhq.org/", url);

            //Arrange
            IWebElement title = wait.Until<IWebElement>(d => { return d.FindElement(By.XPath("/html/head/title"));});
            string pageTitle = title.Text.Trim();

            //Assert
            Assert.IsNotNull(pageTitle);
            Assert.AreEqual("Selenium - Web Browser Automation", pageTitle);

            Thread.Sleep(2000);
        }
    }
}
