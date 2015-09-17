namespace _02.Decorator.Weapons
{
    public abstract class Weapon
    {
        public Weapon(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; private set; }
    }
}