namespace _01.TemplateMethod
{
    using System; 

    public class BulgarianFootballPlayer : FootballPlayer
    {
        public BulgarianFootballPlayer(string name, string preferedDrink) : base(name)
        {
            this.PreferedDrink = preferedDrink;
        }

        public string PreferedDrink { get; set; }

        protected override void Practice()
        {
            Console.WriteLine("Running around, not doing much, posing tatoos for picture :) Looking good.");
        }

        protected override void Recover()
        {
            Console.WriteLine("Drink some {0}, go to Student Cuty, snap with fingers, drink some more {0} :)", this.PreferedDrink);
        }

        protected override void PlayMatch()
        {
            base.PlayMatch();
            Console.WriteLine("Protecting the hair style, keeping it easy...");
        }
    }
}
