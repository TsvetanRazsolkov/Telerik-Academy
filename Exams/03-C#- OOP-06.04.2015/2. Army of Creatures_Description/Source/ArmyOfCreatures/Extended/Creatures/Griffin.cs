
namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Extended.Specialties;

    public class Griffin : Creature
    {
        private const int GriffinAttack = 8;
        private const int GriffinDefense = 8;
        private const int GriffinHealth = 25;
        private const decimal GriffinDamage = 4.5M;
        private const int RoundsActiveForDoubleDefenseWhenDefending = 5;
        private const int RoundsActiveForAddDefenseWhenSkip = 3;

        public Griffin()
            : base(GriffinAttack, GriffinDefense, GriffinHealth, GriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(RoundsActiveForDoubleDefenseWhenDefending));
            this.AddSpecialty(new AddDefenseWhenSkip(RoundsActiveForAddDefenseWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
