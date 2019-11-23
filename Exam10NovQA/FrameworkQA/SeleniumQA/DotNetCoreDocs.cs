namespace SeleniumQA
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumQA.Pages.DotNetCoreDocsPage;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class DotNetCoreDocs : BaseTest
    {
        private DotNetCoreDocsPage _page;
//        private int testIndex;

        [SetUp]
	    public void SetUp()
	    {
		    Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
		    Driver.Manage().Window.Maximize();
		    Driver.Navigate().GoToUrl("https://docs.microsoft.com/en-us/dotnet/");
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

	    [Test]
        [TestCase(0)]       
 //       [TestCase(1)]
 //       [TestCase(2)]
        public void VerifyDotNetCoreScrollInArticles(int testIndex)
	    {
		    _page = new DotNetCoreDocsPage(Driver);

            //			_page.GuideLinks[testIndex].Click();
            _page.Guide1.Click();
            DelayForVideo();

            //            _page.TopicExpanders[testIndex].Click();
            _page.Topic1.Click();
            DelayForVideo();

            //           _page.ScrollTo(_page.ArticleLinks[testIndex]);
            _page.ScrollTo(_page.Article1);
            DelayForVideo();
            //            _page.ArticleLinks[testIndex].Click();
            _page.Article1.Click();
            DelayForVideo();

            for (int i = 0; i < _page.ItemLinks.Count; i++)
            {
                double startPos = _page.Position;
                _page.ItemLinks[i].Click();
                DelayForVideo();

                double endPos = _page.Position;

                startPos.Should().BeLessThan(endPos);
                _page.SectionsNames[i].Should().BeEquivalentTo(_page.NavigationLinksNames[i]);
            }
        }

        [Test]
        public void VerifyPositiveVoteWithout_FeedBack()
        {
            _page = new DotNetCoreDocsPage(Driver);

            _page.Guide1.Click();
            DelayForVideo();

            _page.Topic1.Click();

            _page.ScrollTo(_page.Article1);
            DelayForVideo();
            _page.Article1.Click();
            DelayForVideo();

            _page.YesButton.Click();
            DelayForVideo();
            _page.SkipButton.Click();
            DelayForVideo();
            _page.ThankYou.Text.Should().BeEquivalentTo("Thank you.");
        }

        [Test]
        public void VerifyPositiveVoteWith_FeedBack()
        {
            _page = new DotNetCoreDocsPage(Driver);

            _page.Guide1.Click();
            DelayForVideo();

            _page.Topic1.Click();
            DelayForVideo();

            _page.ScrollTo(_page.Article1);
            DelayForVideo();
            _page.Article1.Click();
            DelayForVideo();

            _page.YesButton.Click();
            DelayForVideo();

            //            _page.SetTextAreaValue(_page.Feedback);
            _page.FeedBack.Click();
            _page.FeedBack.SendKeys("I");
            DelayForVideo();
            _page.SubmitButton.Click();

            DelayForVideo();
            _page.ThankYou.Text.Should().BeEquivalentTo("Thank you.");
        }
    }
}
