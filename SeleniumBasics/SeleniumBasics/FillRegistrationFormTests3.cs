namespace SeleniumBasics
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System.Threading;

    [TestFixture]
    public class FillRegistrationFormTests3: SetupTest
    {
        [Test]
        public void FillRegistrationForm()
        {
            //Arrange
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            IWebElement signInButton = driver.FindElement(By.CssSelector(".header_user_info"));    // IWebElement signInButton = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a"));

            //Act
            signInButton.Click();
            IWebElement eMailInput = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("email_create")); });
            eMailInput.SendKeys("peter@mail.bg");

            IWebElement submitCreate = driver.FindElement(By.Id("SubmitCreate"));
            submitCreate.Click();

            //Assert
            IWebElement createAccountForm = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("create-account_form")); });
            string formLogo = createAccountForm.Text.Trim().Substring(0, 17);
            string url = driver.Url;
            Assert.IsNotNull(formLogo);
            Assert.AreEqual("CREATE AN ACCOUNT", formLogo);
            Assert.IsNotNull(url);
            Assert.AreEqual("http://automationpractice.com/index.php?controller=authentication&back=my-account", url);

            IWebElement genderManButton = wait.Until((d) => { return d.FindElement(By.Id("id_gender1")); });
            genderManButton.Click();
            Thread.Sleep(5000);

            IWebElement firstNameInput = wait.Until<IWebElement>(f => { return f.FindElement(By.Id("customer_firstname")); });
            firstNameInput.SendKeys("Peter");

            //Assert
            string firstName = firstNameInput.GetAttribute("value");
            Assert.IsNotNull(firstName);
            Assert.AreEqual("Peter", firstName);

            IWebElement lastNameInput = wait.Until<IWebElement>(l => { return l.FindElement(By.Id("customer_lastname")); });
            lastNameInput.SendKeys("Draganov");

            //Assert
            string lastName = lastNameInput.GetAttribute("value");
            Assert.IsNotNull(lastName);
            Assert.AreEqual("Draganov", lastName);

            IWebElement passwordInput = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("passwd")); });
            passwordInput.SendKeys("123456");

            //Assert
            string passwd = passwordInput.GetAttribute("value");
            Assert.IsNotNull(passwd);
//            Assert.IsTrue(passwd.Length > 10);

            IWebElement days = wait.Until((d) => { return d.FindElement(By.Id("days")); });
            SelectElement birthDay = new SelectElement(days);
            birthDay.SelectByIndex(25);

            //Assert
            Assert.AreEqual("25", birthDay.SelectedOption.GetAttribute("value"));

            IWebElement months = wait.Until((d) => { return d.FindElement(By.Id("months")); });
            SelectElement birthMonth = new SelectElement(months);
            birthMonth.SelectByIndex(08);

            //Assert
            Assert.AreEqual("August", birthMonth.SelectedOption.Text.Trim());

            IWebElement years = wait.Until((d) => { return d.FindElement(By.Id("years")); });
            SelectElement birthYear = new SelectElement(years);
            birthYear.SelectByText("1981", true);

            //Assert
            Assert.AreEqual("1981", birthYear.SelectedOption.Text.Trim());

            IWebElement newsletterCheckBox = wait.Until((d) => { return d.FindElement(By.Id("newsletter")); });
            newsletterCheckBox.Click();

            IWebElement address1 = wait.Until<IWebElement>(l => { return l.FindElement(By.Id("address1")); });
            string address1Text = "89341 Broadway, Honolulu, HA 98122, United States";
            int expected = address1Text.Length;
            address1.SendKeys(address1Text);         

            //Assert
            string address1Displayed = address1.GetAttribute("value");
            Assert.IsNotNull(address1Displayed);
            int displayedTextLength = address1Displayed.Length;
            Assert.AreEqual(expected, displayedTextLength);
            Assert.That(address1Displayed.Contains("Honolulu"));

            IWebElement city = wait.Until<IWebElement>(c => { return c.FindElement(By.Id("city")); });
            city.SendKeys("Honolulu");

            //Assert
            string cityDisplayed = city.GetAttribute("value");
            Assert.IsNotNull(cityDisplayed);
            Assert.AreEqual("Honolulu", cityDisplayed);

            IWebElement id_state = wait.Until((d) => { return d.FindElement(By.Id("id_state")); });
            SelectElement state = new SelectElement(id_state);
            state.SelectByText("Hawaii", true);

            //Assert
            Assert.AreEqual("Hawaii", state.SelectedOption.Text.Trim());

            IWebElement postcode = wait.Until<IWebElement>(p => { return p.FindElement(By.Id("postcode")); });
            postcode.SendKeys("89341");

            //Assert
            string postcodeDisplayed = postcode.GetAttribute("value");
            Assert.IsNotNull(postcodeDisplayed);
            Assert.AreEqual("89341", postcodeDisplayed);

            IWebElement id_country = wait.Until((d) => { return d.FindElement(By.Id("id_country")); });
            SelectElement country = new SelectElement(id_country);
            country.SelectByText("United States", true);

            //Assert
            Assert.AreEqual("United States", country.SelectedOption.Text.Trim());  

            IWebElement phoneMobile = wait.Until<IWebElement>(p => { return p.FindElement(By.Id("phone_mobile")); });
            phoneMobile.SendKeys("+359888456321");

            //Assert
            string mobileDisplayed = phoneMobile.GetAttribute("value");
            Assert.IsNotNull(mobileDisplayed);
            Assert.AreEqual("+359888456321", mobileDisplayed);

/*            //Arrange
            IWebElement submitAccountButton = wait.Until<IWebElement>(s => { return s.FindElement(By.Id("submitAccount")); });
            //Act
            submitAccountButton.Click();
            string myAccountUrl = driver.Url;
            //Assert
            Assert.IsNotNull(myAccountUrl);
            Assert.AreEqual("http://automationpractice.com/index.php?controller=my-account", myAccountUrl); */
        }

        [Test]
        public void NegativeFillFormTests4()
        {
            //Arrange
//            IWebElement submitAccountButton = wait.Until(s => { return s.FindElement(By.Id("submitAccount")); });

            IWebElement firstNameInput = wait.Until<IWebElement>(f => { return f.FindElement(By.Id("customer_firstname")); });
            firstNameInput.Clear();

            //Assert
            string firstName = firstNameInput.GetAttribute("value");
            Assert.IsEmpty(firstName);

            //Arrange
            IWebElement submitAccountButton = wait.Until<IWebElement>(s => { return s.FindElement(By.Id("submitAccount")); });

            //Act
            submitAccountButton.Click();

            //Assert
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
            Assert.AreEqual("firstname is required.", errorMessage.Text.Trim());

            //Arrange
            IWebElement postcode = wait.Until<IWebElement>(p => { return p.FindElement(By.Id("postcode")); });
            postcode.SendKeys("893");
            IWebElement passwordInput = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("passwd")); });
            passwordInput.SendKeys("123456");
            IWebElement submitButton = wait.Until<IWebElement>(s => { return s.FindElement(By.Id("submitAccount")); });
            //Act
            submitButton.Click();

            //Assert
            errorMessage = driver.FindElement(By.XPath("//*[@id='center_column']/div/p"));
            Assert.AreEqual("There are 2 errors", errorMessage.Text.Trim());
            errorMessage = driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
            Assert.AreEqual("firstname is required.", errorMessage.Text.Trim());
            errorMessage = driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li[2]"));
            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", errorMessage.Text.Trim());

            //Arrange
            IWebElement passwInput = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("passwd")); });
            passwInput.SendKeys("sfd");
            string pw = passwInput.GetAttribute("value");
            string pass = pw;
            IWebElement submitAccButton = wait.Until<IWebElement>(s => { return s.FindElement(By.Id("submitAccount")); });
            
            //Act
            submitAccButton.Click();

            //Assert
            errorMessage = driver.FindElement(By.XPath("//*[@id='center_column']/div/p"));
            Assert.AreEqual("There are 3 errors", errorMessage.Text.Trim());
            errorMessage = driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li[2]"));
            Assert.AreEqual("passwd is invalid.", errorMessage.Text.Trim());

            //Arrange
            IWebElement phoneMobile = wait.Until<IWebElement>(d => { return d.FindElement(By.Id("phone_mobile")); });
            phoneMobile.Clear();

            //Assert
            string phone = phoneMobile.GetAttribute("value");
            Assert.IsEmpty(phone);
            IWebElement submitAccntButton = wait.Until<IWebElement>(s => { return s.FindElement(By.Id("submitAccount")); });

            //Act
            submitAccntButton.Click();

            //Assert
            errorMessage = driver.FindElement(By.XPath("//*[@id='center_column']/div/p"));
            Assert.AreEqual("There are 4 errors", errorMessage.Text.Trim());
            errorMessage = driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li[1]"));
            Assert.AreEqual("You must register at least one phone number.", errorMessage.Text.Trim());

            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
