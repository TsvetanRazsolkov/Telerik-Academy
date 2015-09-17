namespace _01.AbstractFactory.Soldiers
{
    using System;

    public class Marine : Soldier
    {
        public Marine(int damage, int intelligence) : base(damage, intelligence)
        {
        }

        public override void Fight()
        {
            Console.WriteLine("Marine hitting with an axe and dealing {0} damage", this.Damage);
        }
    }
}
