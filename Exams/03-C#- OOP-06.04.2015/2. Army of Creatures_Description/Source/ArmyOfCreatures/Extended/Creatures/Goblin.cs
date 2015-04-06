namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class Goblin : Creature
    {
        private const int GoblinAttack = 4;
        private const int GoblinDefense = 2;
        private const int GoblinHealth = 5;
        private const decimal GoblinDamage = 1.5M;

        public Goblin()
            : base(GoblinAttack, GoblinDefense, GoblinHealth, GoblinDamage)
        {
        }
    }
}
