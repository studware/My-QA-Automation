﻿namespace Homework.Pages
{
    using NUnit.Framework;

    public partial class RegistrationPage
    {
        public void AssertErrorMessage(string expected)
        {

            Assert.AreEqual(expected, ErrorMessage.Text);
        }
    }
}
