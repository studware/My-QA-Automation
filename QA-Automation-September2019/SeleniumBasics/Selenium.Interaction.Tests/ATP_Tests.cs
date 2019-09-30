namespace Selenium.Interaction.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using Selenium.Interaction.Tests.Pages.ATP;
    using System.IO;
    using System.Reflection;

    [TestFixture]
	public class ATP_Tests : BaseTest
    {
        private Actions _action;

		[SetUp]
	    public void SetUp()
	    {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _action = new Actions(_driver);
            _driver.Manage().Window.Maximize();
		    _driver.Navigate().GoToUrl("https://www.automatetheplanet.com/");
	    }
        
	    [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void CheckNavigationForBlogPosts(int article)
	    {
            var page = new ATP_Page(_driver);

            page.Blog.Click();
            DelayForVideo();
            page.Articles[article].Click();
            DelayForVideo();

            page.HeadersThree.Should().BeEquivalentTo(page.NavLinksToHeaderThree);
            DelayForVideo();
            page.HeadersTwo.Should().BeEquivalentTo(page.NavLinksToHeaderTwo);
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