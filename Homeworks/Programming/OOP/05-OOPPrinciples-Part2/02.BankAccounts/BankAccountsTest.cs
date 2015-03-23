namespace BankAccounts
{
    using System;

    public class BankAccountsTest
    {
        public static readonly string separator = new string('-', Console.WindowWidth);

        public static void Main()
        {
            Bank someBank = new Bank();
            FillBankWithAccounts(someBank);

            Console.WriteLine("  All accounts in the bank: ");
            PrintBankInfo(someBank);
            Console.Write(separator);

            Console.WriteLine("  All accounts after some withdrawals and deposits: ");
            TestMoneyOperations(someBank);
            PrintBankInfo(someBank);
            Console.Write(separator);

            Console.WriteLine("  All accounts with interest amount calculated over a period of 12 months:");
            TestInterestCalculations(someBank);// For every account for a period of 12 months
            Console.Write(separator);
        }

        private static void TestMoneyOperations(Bank someBank)
        {
            foreach (var acc in someBank.Accounts)
            {
                if (acc is Deposit) // withdraw 75 from every deposit account
                {
                    (acc as Deposit).Withdraw(75M);
                }
                acc.Deposit(0.50M); // deposit 0.50 in every account
            }
        }

        private static void TestInterestCalculations(Bank someBank) // Example for bad cohesion :)
        {
            foreach (var acc in someBank.Accounts)
            {
                Console.WriteLine("{0} account.", acc.GetType().Name);
                Console.Write(acc);
                Console.WriteLine("Interest over 12 months: {0}\n", acc.CalcInterestAmount(12M));
            }
        }

        private static void PrintBankInfo(Bank someBank)
        {
            foreach (var acc in someBank.Accounts)
            {
                Console.WriteLine("{0} account.", acc.GetType().Name);
                Console.WriteLine(acc);
            }
        }

        public static void FillBankWithAccounts(Bank someBank)
        {
            someBank.AddAccount(new Deposit(new Individual("Pesho", "45772121455"), 455.5M, 0.25M));
            someBank.AddAccount(new Loan(new Company("Vaksa Ltd.", "GL0994453", "241555110"), -45000M, 1.25M));
            someBank.AddAccount(new Mortgage(new Individual("Gosho", "451224554552"), -50000M, 0.54M));
            someBank.AddAccount(new Deposit(new Company("Shlyokavica", "ddf232", "454654"), 120000M, 0.15M));
        }
    }
}
