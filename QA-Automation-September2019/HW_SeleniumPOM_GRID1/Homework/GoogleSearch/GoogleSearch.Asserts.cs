namespace Homework.GoogleSearch
{
    using NUnit.Framework;

    public partial class GoogleSearch
    {
        public void FoundResult(string foundResult)
        {
            Assert.AreEqual("Selenium - Web Browser Automation", foundResult);
        }
    }
}
