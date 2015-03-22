namespace BankAccounts
{
    using System;

    public class Mortgage : Account
    {
        private decimal balance;

        public Mortgage(Customer customer, decimal balance, decimal interestRate)
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
                    throw new ArgumentException("Mortgage account balance can not be positive number.");
                }
                this.balance = value;
            }
        }

        public override decimal CalcInterestAmount(decimal numberOfMonths)
        {
            ValidateInputPeriod(numberOfMonths);

            if (this.Customer is Individual)
            {
                if (numberOfMonths <= 6)
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
                if (numberOfMonths <= 12)
                {
                    return base.CalcInterestAmount(numberOfMonths) / 2;
                }
                else
                {
                    return base.CalcInterestAmount(numberOfMonths);
                }
            }            
        }
    }
}
