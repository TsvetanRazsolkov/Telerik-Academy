namespace _04.State
{
    using System;

    /// <summary>
    /// The Context class
    /// </summary>
    public class ATM
    {
        public ATM(decimal availableCash)
        {
            this.AvailableCash = availableCash;
            this.State = new InitialState(this);
        }

        public decimal AvailableCash { get; set; }

        public State State { get; set; }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine(State.GetNextScreen());
            }
        }
    }
}
