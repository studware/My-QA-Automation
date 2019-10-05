namespace SeleniumBasics.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    [TestFixture]
    public class GoogleSearch : SetupTest
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
                              By.XPath("//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input"));
                            });
        //or:    var searchInput = driver.FindElement(By.XPath(@"//input[@class='gLFyf gsfi']"));
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

        // XPath            //*[@id="rso"]/div[2]/div/div/div/div[1]/a/h3/div
        //  Or if the search button is not visible, just click at the page logo:
        //  var logo = driver.FindElement(By.Id("hplogo"));
        //  logo.Click();

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
        }
    }
}


