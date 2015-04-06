
namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Extended.Specialties;

    public class WolfRaider : Creature
    {
        private const int WolfRaiderAttack = 8;
        private const int WolfRaiderDefense = 5;
        private const int WolfRaiderHealth = 10;
        private const decimal WolfRaiderDamage = 3.5M;
        private const int RoundsActiveForDoubleDamage = 7;

        public WolfRaider()
            : base(WolfRaiderAttack, WolfRaiderDefense, WolfRaiderHealth, WolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(RoundsActiveForDoubleDamage));
        }
    }
}
