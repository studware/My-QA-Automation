namespace Selenium.Interaction.Tests.Pages
{
	using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System.Threading;

    public partial class SelectablePage : BasePage
    {
        private Actions _action;

        public SelectablePage(IWebDriver driver) : base(driver)
	    {
	    }
    }
}

