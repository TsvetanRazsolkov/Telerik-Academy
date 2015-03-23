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
            this.accounts = new List<Account>();
        }

        public List<Account> Accounts // Account can only be added through the class method AddAccount()
        {
            get { return new List<Account>(this.accounts); }
        }

        public void AddAccount(Account acc)
        {
            this.accounts.Add(acc);
        }
    }
}
