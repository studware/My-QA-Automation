namespace SeleniumQA
{
	using System.IO;
	using System.Reflection;
	using SeleniumQA.Pages.AutomateThePlanetPage;
	using FluentAssertions;
	using NUnit.Framework;
	using OpenQA.Selenium.Chrome;

	[TestFixture]
    public class T3AutomateThePlanet : BaseTest
    {
		[SetUp]
	    public void SetUp()
	    {
		    Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
		    Driver.Manage().Window.Maximize();
		    Driver.Url = "https://www.automatetheplanet.com/";
	    }

	    [Test]
		[TestCase(2)]
  //      [TestCase(3)]
  //      [TestCase(4)]
	    public void VerifyAutomateThePlanetScrolInArticles(int article)
	    {
		    var page = new ATPPage(Driver);

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
