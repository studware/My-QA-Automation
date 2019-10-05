namespace Selenium.Interaction.Tests.Pages
{
	using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System.Threading;

    public partial class DroppablePage : BasePage
    {
        private Actions _action;

        public DroppablePage(IWebDriver driver) : base(driver)
	    {
	    }

        public void DragAndDropHandle(IWebElement draggable, int offsetX, int offsetY)
        {
            Actions action = new Actions(Driver);

            action.MoveToElement(draggable);

            action.ClickAndHold().DragAndDropToOffset(draggable, offsetX, offsetY).Release();
            action.Build().Perform();
        }
    }
}

