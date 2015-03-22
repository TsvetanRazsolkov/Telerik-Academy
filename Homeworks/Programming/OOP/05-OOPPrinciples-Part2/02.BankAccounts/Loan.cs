namespace BankAccounts
{
    using System;

    public class Loan : Account
    {
        private decimal balance;

        public Loan(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }


        public override decimal Balance
        {
            get
            {
                return this.balance;
            }
            protected set
            {
                if (value > 0)
                {
                    throw new ArgumentException("Loan account balance can not be positive number.");
                }
                this.balance = value;
            }
        }

        public override decimal CalcInterestAmount(decimal numberOfMonths)
        {
            ValidateInputPeriod(numberOfMonths);

            if (this.Customer is Individual)
            {
                if (numberOfMonths <= 3)
                {
                    return 0M;
                }
                else
                {
                    return base.CalcInterestAmount(numberOfMonths);
                }
            }
            else
            {
                if (numberOfMonths <= 2)
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
}
