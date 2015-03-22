namespace BankAccounts
{
    public class Individual : Customer // Reason for having both types of customers in different classes
    // and not as a property of type enumeration in the base class is because they could and should have different identifying fields;
    {
        private string uniqueIdentifier;

        public Individual(string name, string uniqieID) : base(name)
        {
            this.UniqueIdentifier = uniqieID;
        }

        public string UniqueIdentifier
        {
            get { return this.uniqueIdentifier; }
            private set
            {
                //Some validation may be done, depending on what is the identifier - ЕГН, ID number, etc.
                this.uniqueIdentifier = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Identifier: {1}",base.ToString(), this.UniqueIdentifier ); 
        }
    }
}
