namespace SeleniumQA
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumQA.Pages.AutomateThePlanetPage;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class AutomateThePlanet : BaseTest
    {
		[SetUp]
	    public void SetUp()
	    {
		    Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
		    Driver.Manage().Window.Maximize();
		    Driver.Navigate().GoToUrl("https://www.automatetheplanet.com/");
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

	    [Test]
		[TestCase(2)]       // 1,1
        [TestCase(3)]       // 1,2
        [TestCase(7)]       // 3,0
        [TestCase(1)]       // 1,0
	    public void VerifyAutomateThePlanetScrollInArticles(int article)
	    {
		    var page = new ATPPage(Driver);

			page.Blog.Click();
            DelayForVideo();

            int mod = article % 3;
            page.listIndex = (mod != 0) ? (article/3 +1) : article/3;
            article = (mod != 0) ? (mod - 1) : 2;

            page.ScrollTo(page.PostLists[page.listIndex]);
            DelayForVideo();
            page.PostsInList[article].Click();
            DelayForVideo();

            page.ScrollTo(page.Navigation);
            DelayForVideo();
            page.ScrollBelowNavigation();

            page.HeadersTwo.Should().BeEquivalentTo(page.NavLinksToHeaderTwo);
            DelayForVideo();

            page.HeadersThree.Should().BeEquivalentTo(page.NavLinksToHeaderThree);
            DelayForVideo();


            foreach (var link in page.NavigationLinks)
            {
                page.ScrollTo(link);
                page.ScrollBelowNavigation();
                DelayForVideo(2);
                double startPos = page.Position;
                link.Click();
                DelayForVideo();
                double endPos = page.Position;

                startPos.Should().BeLessThan(endPos);
                page.ScrollToTop();
                DelayForVideo();
            }
        }
    }
}
