namespace BankAccounts
{
    using System;
    using System.Text;

    public abstract class Account : IDeposit
    {
        private Customer customer;
        private decimal interestRatePerMonth;

        public Account(Customer customer, decimal balance, decimal interestRate )
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRatePerMonth = interestRate;
        }

        public Customer Customer
        {
            get { return this.customer; }
            private set
            {
                this.customer = value;
            }
        }

        public abstract decimal Balance{ get; protected set; } // Abstract, so overrides can make different validations 
                                                             // for different types of accounts

        public decimal InterestRatePerMonth
        {
            get { return this.interestRatePerMonth; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Interest rate per month can not be negative.");
                }
                this.interestRatePerMonth = value;
            }
        }

        public virtual decimal CalcInterestAmount(decimal numberOfMonths)
        {
            return numberOfMonths * this.InterestRatePerMonth;
        }

        public void ValidateInputPeriod(decimal period)
        {
            if (period <= 0)
            {
                throw new ArgumentException("Period of months to calculate the interest rate must be bigger than zero.");
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposited sum can not be 0 or less than 0.");
            }
            this.Balance += amount;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(this.Customer.GetType().Name + " customer: " + this.Customer);
            result.AppendFormat("Balance = {0:C}\n", this.Balance);
            result.AppendLine("Interest rate per month: " + this.InterestRatePerMonth + "%");

            return result.ToString();
        }
    }
}
