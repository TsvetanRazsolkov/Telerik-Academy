namespace BankAccounts
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Bank
    {
        private List<Account> accounts;

        public Bank()
        {
            this.Accounts = new List<Account>();
        }

        public List<Account> Accounts
        {
            get { return this.accounts; }
            private set
            {
                this.accounts = value;
            }
        }
    }
}
