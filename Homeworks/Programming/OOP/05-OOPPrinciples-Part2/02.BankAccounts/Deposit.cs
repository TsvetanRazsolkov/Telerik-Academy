namespace BankAccounts
{
    using System;

    public class Deposit : Account, IWithdrawal
    {
        private decimal balance;

        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Deposit balance can not be less than zero.");
                }
                this.balance = value;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException("Amount to withdraw can not be more than the deposit's balance.");
            }
            this.Balance -= amount;
        }

        public override decimal CalcInterestAmount(decimal numberOfMonths)
        {
            ValidateInputPeriod(numberOfMonths);

            if (this.Balance < 1000)
            {
                return 0M;
            }
            else
            {
                return base.CalcInterestAmount(numberOfMonths);
            }
        }
    }
}
