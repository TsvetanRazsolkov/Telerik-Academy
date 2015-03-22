namespace BankAccounts
{
    using System;

    public abstract class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or emprty string");
                }
                this.name = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
