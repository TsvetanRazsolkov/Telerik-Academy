namespace _01.TemplateMethod
{
    using System;

    public class GermanFootballPlayer : FootballPlayer
    {
        public GermanFootballPlayer(string name) : base(name)
        {
        }

        protected override void Practice()
        {
            Console.WriteLine("Training hard with and without a ball, learning tactics.");
        }

        protected override void Recover()
        {
            Console.WriteLine("Rest, sleep, relax.");
        }

        protected override void PlayMatch()
        {
            base.PlayMatch();
            Console.WriteLine("Working hard, while thinking.");
        }
    }
}
