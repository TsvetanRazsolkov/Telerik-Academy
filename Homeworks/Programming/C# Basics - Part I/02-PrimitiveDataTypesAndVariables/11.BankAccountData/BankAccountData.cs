using System;

class BankAccountData
{
    static void Main()
    {
        //A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account. Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

        string holderName = "Ivan Ivanov Ivanov";
        decimal balance = 0.50M;
        string bankName = "Some bank";
        string IBAN = "Some code";
        ulong creditCard1 = 1111000011110000;
        ulong creditCard2 = 0000111100001111;
        ulong creditCard3 = 0101010101010101;
    }
}