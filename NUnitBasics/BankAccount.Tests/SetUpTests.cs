namespace BankAccount.Tests
{
    using NUnit.Framework;
    using System;

    [SetUpFixture]

    public class SetUpTests
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // Executes once before the test run.
            BankAccount account = new BankAccount(0m);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            // Executes once after the test run. (Optional)
        }
    }
}

