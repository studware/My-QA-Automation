using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Pages
{
    public partial class RegistrationPage
    {
        public void AssertErrorMessage(string expected)
        {

            Assert.AreEqual(expected, ErrorMessage.Text);
        }
    }
}
