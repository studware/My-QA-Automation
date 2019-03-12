namespace SeleniumBasics.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
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
            driver.FindElement(By.TagName("center")).FindElement(By.Name("btnK")).Click();
            IWebElement seleniumLink = wait.Until<IWebElement>(fl => { 
                                        return fl.FindElement(By.Id("rso"))
                                        .FindElement(By.TagName("a")); });

            Thread.Sleep(2000);

           string seleniumLinkText = seleniumLink.Text;
           seleniumLink.Click();
           
           //Assert
           Assert.That(seleniumLinkText.Contains("Selenium - Web Browser Automation"));
            string url = driver.Url;
            Assert.IsNotNull(url);
            Assert.AreEqual("https://www.seleniumhq.org/", url);

            //Arrange
            IWebElement title = wait.Until<IWebElement>(d => { return d.FindElement(By.TagName("title"));});
            string pageTitle = title.GetAttribute("text").Trim();

            //Assert
            Assert.IsNotNull(pageTitle);
            Assert.AreEqual("Selenium - Web Browser Automation", pageTitle);

            Thread.Sleep(2000);
        }
    }
}

/*      Using XPath for Selenium URL without wait:
     
        IWebElement firstLink = driver.FindElement(By
            .XPath(@"//*[@id=""rso""]/div[1]/div/div/div[2]/div[1]/a")); */

/*      Using XPath for Selenium URL with wait:
      
    IWebElement seleniumLink = wait.Until<IWebElement>(fl => {
        return fl.FindElement(
        By.XPath("//*[@id='rso']/div/div/div[1]/div/div/div[1]/a[1]"));});      */

