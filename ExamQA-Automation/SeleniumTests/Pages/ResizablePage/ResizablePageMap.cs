namespace SeleniumTests.Pages.ResizablePage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OpenQA.Selenium;

    public partial class ResizablePage
    {
        public IWebElement ResizeableLink => Wait.Until(d => { return d.FindElement(By.XPath("//a[contains(text(),'Resizable')]")); });

        public IWebElement ResizeableItem => Wait.Until(d => { return d.FindElement(By.XPath("//div[@id='resizable']")); });

        public IWebElement ResizeDiagonal => Wait.Until(d => { return d.FindElement(By.XPath("//div[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']")); });
    }
}
