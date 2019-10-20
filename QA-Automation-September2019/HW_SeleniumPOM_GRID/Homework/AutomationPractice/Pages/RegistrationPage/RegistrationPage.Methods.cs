namespace Homework.Pages
{
    using Homework.Extensions;
    using OpenQA.Selenium;

    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillForm(RegistrationUser user)
        {
            FemaleButton.Click();
            CustomerFirstName.Type(user.FirstName);
            CustomerLastName.Type(user.LastName);
            Password.Type(user.Password);
            Days.SelectByValue(user.Date);
            Months.SelectByValue(user.Month);
            Years.SelectByValue(user.Year);
            FirstName.Clear();
            FirstName.Type(user.FirstName);
            LastName.Type(user.LastName);
            Address.Type(user.Address);
            City.Type(user.City);
            State.SelectByText(user.State);
            PostCode.Type(user.PostCode);
            Phone.Type(user.Phone);
            Alias.Type(user.Alias);
            RegisterButton.Click();
        }
    }
}
