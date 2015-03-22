namespace BankAccounts
{
    public class Company : Customer // Reason for having both types of customers in different classes
    // and not as a property of type enumeration in the base class is because they could and should have different identifying fields;
    {
        private string tradeRegistryNumber;
        private string bulstatNumber;

        public Company(string name, string tradeRegNum, string bulstat) 
            : base(name)
        {
            this.TradeRegistryNumber = tradeRegNum;
            this.BulstatNumber = bulstat;
        }

        public string TradeRegistryNumber
        {
            get { return this.tradeRegistryNumber; }
            private set
            {
                // Validation for compliance with the possible values of the argument;
                this.tradeRegistryNumber = value;
            }
        }

        public string BulstatNumber
        {
            get { return this.bulstatNumber; }
            private set
            {
                // Validation for compliance with the possible values of the argument;
                this.bulstatNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Trade registry number: {1}, BULSTAT: {2}",
                                 base.ToString(), this.TradeRegistryNumber, this.BulstatNumber);
        }
    }
}
