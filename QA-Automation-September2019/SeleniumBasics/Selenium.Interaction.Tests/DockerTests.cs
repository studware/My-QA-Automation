namespace Selenium.Interaction.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using Selenium.Interaction.Tests.Pages.Docker;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    [TestFixture]
	public class DockerTests : BaseTest
    {
        private Actions _action;

		[SetUp]
	    public void SetUp()
	    {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _action = new Actions(_driver);
            _driver.Manage().Window.Maximize();
		    _driver.Navigate().GoToUrl("https://docs.microsoft.com/en-us/dotnet/csharp/ ");
	    }
        
	    [Test]
        public void CheckNavigationForDockerGuide()
	    {
            var page = new DockerPage(_driver);

            page.DotNETCoreGuide.Click();
            DelayForVideo();

            page.Docker.Click();
            DelayForVideo();

            List<string> artext = new List<string>();

            foreach (var article in page.Articles)
            {
                artext.Add(article.Text);
                article.Click();
                DelayForVideo();



 //               page.HeadersTwo.Should().BeEquivalentTo(page.NavLinksToHeaderTwo);
                DelayForVideo();
            }

/*            foreach (var link in page.NavigationLinks)
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
            } */
        }
    }
}