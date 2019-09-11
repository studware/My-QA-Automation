namespace BankAccount.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]

    public class DepositTests
    {
        [Test]
        public void CreateBankAccountWithNegativeInitialValueShouldThrowArgumentException()
        {
            //Arrange&Act&Assert
            Assert.Throws<ArgumentException>(() => new BankAccount(-10.5M));
        }

        [Test]
        public void CreateBankAccountWithNegativeInitialValueShouldThrowExceptionWithMessage()
        {
            //Arrange&Act&Assert
            var exception = Assert.Throws<ArgumentException>(() => new BankAccount(-10.5M));
            Assert.AreEqual("Amount can not be negative!", exception.Message);
        }

        [Test]
        public void CreateBankAccountWithZeroInitialValue()
        {
            //Arrange&Act
            var account = new BankAccount(0m);

            //Assert
            Assert.That(account.Amount == 0m);
        }

        [Test]
        public void CreateBankAccountWithPositiveInitialValue()
        {
            //Arrange&Act
            var acc = new BankAccount(10.5m);

            //Assert
            Assert.That(acc.Amount == 10.5m);

            //   acc.Amount.Should().Be(10.5m);    // supported by FluentAssertions
        }

        [Test]
        public void BankAccountWithPositiveValueShouldNotBeLessThanZero()
        {
            //Arrange&Act
            var acc = new BankAccount(10.5m);

            //Assert
            Assert.IsFalse(acc.Amount < 0m);
        }

        [Test]
        public void DepositShouldIncreaseAvailableAmount()
        {
            //Arrange
            var acc = new BankAccount(596m);
            decimal initialAmount = acc.Amount;
            decimal deposit = 1000m;

            //Act
            acc.Deposit(deposit);

            //Assert
            Assert.That(acc.Amount.Equals(initialAmount + deposit));
        }

        [Test]
        public void checkNewAccIsNotNull()
        {
            //Arrange&Act
            var acc = new BankAccount(10000m);

            //Assert
            Assert.IsNotNull(acc);
        }

        [Test]
        public void checkNewAccHasMoney()
        {
            //Arrange&Act
            var acc = new BankAccount(10000m);

            //Assert
            Assert.IsTrue(acc.Amount > 0);
        }
    }
}

