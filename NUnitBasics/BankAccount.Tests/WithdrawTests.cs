namespace BankAccount.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]

    public class WithdrawTests
    {
        [Test]
        [TestCase(590.8)]
        [TestCase(999.99)]
        public void WithdrawAmountLessThan1000ShouldTransferFeeFivePercents(decimal withdrawAmount)
        {
            //Arrange
            var account = new BankAccount(2500m);

            decimal expectedAmount = withdrawAmount * 1.05m;
            expectedAmount = account.Amount - expectedAmount;

            //Act
            account.Withdraw(withdrawAmount);

            decimal actualAmount = account.Amount;

            //Assert
            Assert.That(actualAmount.Equals(expectedAmount));
        }

        [Test]
        [TestCase(1000)]
        [TestCase(1578.85)]
        public void WithdrawAmountGreaterThan1000ShouldTransferFeeTwoPercents(decimal withdrawAmount)
        {
            //Arrange
            var account = new BankAccount(4000m);

            decimal expectedAmount = withdrawAmount * 1.02m;
            expectedAmount = account.Amount - expectedAmount;

            //Act
            account.Withdraw(withdrawAmount);

            decimal actualAmount = account.Amount;

            //Assert
            Assert.That(actualAmount.Equals(expectedAmount));
        }

        [Test]
        [TestCase(1200, 0.02)]
        [TestCase(178.85, 0.05)]
        public void ResidualAmountShouldBeLessThanTransferFee(decimal withdrawAmount, decimal transferFee)
        {
            //Arrange
            var acc = new BankAccount(1500m);

            decimal withdrawnAmount = withdrawAmount * (1 + transferFee);
            decimal expectedAmount = acc.Amount - withdrawnAmount;

            //Act
            acc.Withdraw(withdrawAmount);

            decimal actualAmount = acc.Amount;

            //Assert
            Assert.That(actualAmount.Equals(expectedAmount));
        }

        [Test]
        public void WithdrawNegativeAmountShouldThrowException()
        {
            //Arrange
            var amount = new BankAccount(1500m);
            decimal withdrawAmount = -100m;

            //Act&Assert
            Assert.Throws<ArgumentException>(() => amount.Withdraw(withdrawAmount), 
                "This test does not pass ever, because there is not such checkup in BankAccount class!");
        }

        [Test]
        public void WithdrawMoreThanAvailableAmountMinusTransferFeeShouldThrowException()
        {
            //Arrange
            var amount = new BankAccount(1000m);
            decimal withdrawAmount = 1000m;

            //Act&Assert
            Assert.Throws<ArgumentException>(() => amount.Withdraw(withdrawAmount));
        }

        [Test]
        public void WithdrawZeroFromZeroAmountShouldNotThrowException()
        {
            //Arrange
            var amount = new BankAccount(0m);
            decimal withdrawAmount = 0m;

            //Act&Assert
            Assert.DoesNotThrow(() => amount.Withdraw(withdrawAmount));
        }
    }
}
