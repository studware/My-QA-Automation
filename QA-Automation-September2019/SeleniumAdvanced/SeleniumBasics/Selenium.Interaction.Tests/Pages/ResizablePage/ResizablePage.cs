namespace Selenium.Interaction.Tests.Pages.ResizablePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class ResizablePage : BasePage
    {
        public ResizablePage(IWebDriver driver) : base(driver)
        {
        }

        public void Resize(IWebElement element, int offSetX, int offSetY)
        {
            int width = element.Size.Width;
            int height = element.Size.Height;

            Actions action = new Actions(Driver);

            action.MoveToElement(element, width, height);
            action.ClickAndHold().MoveByOffset(offSetX, offSetY).Release();
            action.Build().Perform();
        }
    }
}
