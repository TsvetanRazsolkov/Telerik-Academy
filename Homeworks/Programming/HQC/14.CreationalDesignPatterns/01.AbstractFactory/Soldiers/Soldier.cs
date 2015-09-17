namespace _01.AbstractFactory.Soldiers
{
    public abstract class Soldier
    {
        public Soldier(int damage, int intelligence)
        {
            this.Damage = damage;
            this.Intelligence = intelligence;
        }

        protected int Damage { get; set; }

        protected int Intelligence { get; set; }

        public abstract void Fight();
    }
}
