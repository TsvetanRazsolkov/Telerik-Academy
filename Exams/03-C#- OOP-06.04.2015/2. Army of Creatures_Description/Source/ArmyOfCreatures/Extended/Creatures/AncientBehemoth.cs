
namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class AncientBehemoth : Creature 
    {
        private const int AncientBehemotAttack = 19;
        private const int AncientBehemotDefense = 19;
        private const int AncientBehemotHealth = 300;
        private const decimal AncientBehemotDamage = 40M;
        private const int ReducedDamage = 80;
        private const int RoundsActiveForDefenseSpeciality = 5;

        public AncientBehemoth()
            : base(AncientBehemotAttack, AncientBehemotDefense, AncientBehemotHealth, AncientBehemotDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(ReducedDamage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(RoundsActiveForDefenseSpeciality));
        }
    }
}
