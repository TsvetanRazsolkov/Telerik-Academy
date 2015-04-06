
namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Extended.Specialties;

    public class CyclopsKing : Creature
    {
        private const int CyclopsKingAttack = 17;
        private const int CyclopsKingDefense = 13;
        private const int CyclopsKingHealth = 70;
        private const decimal CyclopsKingDamage = 18M;
        private const int RoundsActiveForAddAttWhenSkip = 3;
        private const int RoundsActiveForDoubleAttackWhenAttacking = 4;
        private const int RoundsActiveForDoubleDamage = 1;

        public CyclopsKing()
            : base(CyclopsKingAttack, CyclopsKingDefense, CyclopsKingHealth, CyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(RoundsActiveForAddAttWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(RoundsActiveForDoubleAttackWhenAttacking));
            this.AddSpecialty(new DoubleDamage(RoundsActiveForDoubleDamage));
        }
    }
}
