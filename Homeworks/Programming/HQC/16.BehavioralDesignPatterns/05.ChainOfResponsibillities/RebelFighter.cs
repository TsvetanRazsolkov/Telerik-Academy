namespace _05.ChainOfResponsibillities
{
    using System;

    /// <summary>
    /// Concrete Handler class
    /// </summary>
    public class RebelFighter : GalacticHero
    {
        public RebelFighter(string name, int strength) : base(name, strength)
        {
        }

        public override void DefeatVillain(Villain villain)
        {
            if (this.Strength >= villain.Evilness)
            {
                Console.WriteLine("Galactic hero {0} {1} defeats evil {2}", this.GetType().Name, this.Name, villain.Name);
            }
            else if (this.Successor != null)
            {
                this.Successor.DefeatVillain(villain);
            }
            else
            {
                Console.WriteLine("Oh no, galactic hero {0} was hit with a broom and killed by evil {1}", this.Name, villain.Name);
            }
        }
    }
}
