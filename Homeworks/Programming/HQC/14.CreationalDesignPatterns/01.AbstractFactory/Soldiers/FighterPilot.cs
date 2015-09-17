namespace _01.AbstractFactory.Soldiers
{
    using System;

    public class FighterPilot : Soldier
    {
        public FighterPilot(int damage, int intelligence) : base(damage, intelligence)
        {
        }

        public override void Fight()
        {
            Console.WriteLine("Fighter pilot throwing water balloons from an airplane and splashing {0} damage.", this.Damage);
        }
    }
}
