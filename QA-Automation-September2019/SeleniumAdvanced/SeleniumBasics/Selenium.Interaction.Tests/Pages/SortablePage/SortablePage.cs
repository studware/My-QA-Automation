namespace Selenium.Interaction.Tests.Pages
{
	using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class SortablePage : BasePage
    {
        private Actions _action;

        public SortablePage(IWebDriver driver) : base(driver)
	    {
	    }

        public void DragAndDropElement(IWebElement sortable, int offsetX, int offsetY)
        {
            Actions action = new Actions(Driver);

            action.MoveToElement(sortable);

            action.DragAndDropToOffset(sortable, offsetX, offsetY).Release().Perform();
        }
    }
}

