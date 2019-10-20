namespace Homework.GoogleSearch
{
    using NUnit.Framework;

    public partial class GoogleSearchPage
    {
        public void AssertPageTitle(string expected)
        {
            var actualTitle = Driver.Title;

            Assert.AreEqual(expected, actualTitle);
        }
    }
}
