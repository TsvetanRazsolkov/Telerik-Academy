namespace _01.TemplateMethod
{
    using System;

    /// <summary>
    /// The 'AbstractClass'
    /// </summary>
    public abstract class FootballPlayer
    {
        public FootballPlayer(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void PlayFootball()
        {
            this.Practice();
            this.TakeShower();
            this.Recover();
            this.PlayMatch();
            this.TakeShower();
            this.Recover();
        }

        protected abstract void Practice();

        protected void TakeShower()
        {
            Console.WriteLine("Taking a long, lonely shower... :)");
        }

        protected abstract void Recover();

        protected virtual void PlayMatch()
        {
            Console.WriteLine("Kicking a ball around and running...");
        }
    }
}
