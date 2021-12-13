using System;
using NUnit.Framework;

namespace BankAccount.Test
{
    [TestFixture]
    public class BankAccountTest
    {
        private Tests.BankAccount account;

        [SetUp]
        public void InitializeBankAccount()
        {
            account = new Tests.BankAccount(1000);

        }

        [Test]
        public void InitializeBankAccWithAmount()
        {
            Assert.That(account.Amount, Is.EqualTo(1000));
        }

        [Test]
        public void DepositPositiveAmount()
        {
            account.Deposit(220);
            Assert.AreEqual(1220, account.Amount);
            //Assert.That(account.Amount, Is.EqualTo(2000));
        }

        [Test]
        public void DepositNegativeAmount()
        {
            Assert.That(() => account.Deposit(-55), 
                Throws.InvalidOperationException.With.Message
                    .EqualTo("Deposit must be more than 0"));
        }
    }
}
