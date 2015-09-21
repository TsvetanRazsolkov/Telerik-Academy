namespace _04.State
{
    using System;

    /// <summary>
    /// Concrete State class
    /// </summary>
    public class CardValidatedState : State
    {
        public CardValidatedState(ATM atm) : base(atm)
        {
        }

        public override string GetNextScreen()
        {
            string userInput = Console.ReadLine();

            int requestAmount;
            bool result = int.TryParse(userInput, out requestAmount);

            if (result == true)
            {
                if (this.Atm.AvailableCash < requestAmount)
                {
                    return "Amount not present. Enter new amount:";
                }

                this.Atm.AvailableCash -= requestAmount;
                this.Atm.State = new CashWithdrawnState(this.Atm);

                return string.Format("{0:c} has been withdrawn. Press Enter to proceed", requestAmount);
            }

            return "Invalid Amount";
        }
    }
}
