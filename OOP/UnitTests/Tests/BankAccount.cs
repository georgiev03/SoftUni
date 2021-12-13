using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class BankAccount
    {
        private decimal amount;

        public decimal Amount
        {
            get => amount;
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Amount cannot be negative");
                }

                amount = value;
            }
        }

        public BankAccount(decimal amount)
        {
            Amount = amount;
        }

        public void Deposit(decimal depositAmount)
        {
            if (depositAmount <= 0)
            {
                throw new InvalidOperationException("Deposit must be more than 0");
            }

            Amount += depositAmount;
        }

       

        public void Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount <= 0)
            {
                throw new InvalidOperationException("Withdraw must be more than 0");
            }

            Amount -= withdrawAmount;
        }
    }
}
