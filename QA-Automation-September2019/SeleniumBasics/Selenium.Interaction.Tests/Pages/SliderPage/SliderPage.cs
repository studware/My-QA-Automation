namespace Selenium.Interaction.Tests.Pages
{
	using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class SliderPage : BasePage
    {
	    public SliderPage(IWebDriver driver) : base(driver)
	    {
	    }

        public void MoveSliderHandle(IWebElement element, int offsetX, int offsetY)
        {
            int width = element.Size.Width;

            Actions action = new Actions(Driver);

//            action.MoveToElement(element, 0, 0);
            action.ClickAndHold().MoveByOffset(offsetX, 0).Release();
            action.Build().Perform();
        }
    }
}

