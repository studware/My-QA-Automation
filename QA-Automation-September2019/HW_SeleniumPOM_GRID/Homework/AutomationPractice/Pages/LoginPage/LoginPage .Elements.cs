﻿namespace Homework.Pages
{
    using OpenQA.Selenium;

    public partial class LoginPage
    {
        public string GetUrl()
        {
            return "http://automationpractice.com/index.php?controller=my-account";
        }

        public IWebElement Email => Driver.FindElement(By.Id("email_create"));
        public IWebElement Submit => Driver.FindElement(By.Id("SubmitCreate"));      
    }
}
