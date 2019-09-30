namespace Selenium.Interaction.Tests.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class DroppablePage : BasePage
    {
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

