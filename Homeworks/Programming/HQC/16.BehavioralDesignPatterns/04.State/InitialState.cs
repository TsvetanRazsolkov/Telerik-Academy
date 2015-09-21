namespace _04.State
{
    using System;

    /// <summary>
    /// Concrete State class
    /// </summary>
    public class InitialState : State
    {
        public InitialState(ATM atm) : base(atm)
        {
        }

        public override string GetNextScreen()
        {
            Console.WriteLine("Enter your PIN:");
            string userInput = Console.ReadLine();

            if (userInput.Trim() == "0000")
            {
                this.Atm.State = new CardValidatedState(this.Atm);
                return "Enter the amount to withdraw:";
            }

            return "Invalid PIN";
        }
    }
}
