namespace _04.State
{
    using System;

    /// <summary>
    /// Concrete State class
    /// </summary>
    public class CashWithdrawnState : State
    {
        public CashWithdrawnState(ATM atm) : base(atm)
        {
        }

        public override string GetNextScreen()
        {
            this.Atm.State = new InitialState(this.Atm);

            return string.Format("Amount left in ATM: {0:c}. Please don't rob us:)", this.Atm.AvailableCash);
        }
    }
}
