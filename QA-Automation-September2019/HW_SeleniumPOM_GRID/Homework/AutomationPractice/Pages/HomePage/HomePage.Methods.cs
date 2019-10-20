namespace Homework.Pages
{
    public partial class HomePage : BasePage
    {
       public void NavigateToLoginPage(HomePage homePage)
        {
            homePage.Navigate("http://automationpractice.com/index.php");
            SignInButton.Click();
        }
    }
}
