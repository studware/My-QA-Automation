namespace Homework.Pages
{
    using Homework.Extensions;
    using Homework.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public partial class RegistrationPage : BasePage
    {
        public void FillForm(RegistrationUser user)
        {
            FemaleButton.Click();
            CustomerFirstName.SendKeys(user.FirstName);
            CustomerLastName.SendKeys(user.LastName);
            Password.SendKeys(user.Password);
            Days.SelectByValue(user.Date);
            Months.SelectByValue(user.Month);
            Years.SelectByValue(user.Year);
            FirstName.Clear();
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            State.SelectByText(user.State);
            PostCode.SendKeys(user.PostCode);
            Phone.SendKeys(user.Phone);
            Alias.Type(user.Alias);
            RegisterButton.Click();
        }

        public void Navigate(LoginPage loginPage)
        {
            loginPage.Navigate("http://automationpractice.com/index.php?controller=my-account");

            loginPage.Email.SendKeys(RandomGenerator.GenerateMail());

            loginPage.Submit.Click();
        }
    }
}
