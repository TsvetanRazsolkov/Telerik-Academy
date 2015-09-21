namespace _04.State
{
    /// <summary>
    /// Abstract State class
    /// </summary>
    public abstract class State
    {
        protected State(ATM atm)
        {
            this.Atm = atm;
        }

        protected ATM Atm { get; private set; }

        public abstract string GetNextScreen();
    }
}
