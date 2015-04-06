
namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Battles;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private const int MinRoundsForEffect = 0;

        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            if (rounds <= MinRoundsForEffect)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than " + MinRoundsForEffect);
            }

            this.rounds = rounds;
        }        

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("defenderWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("attacker");
            }

            if (this.rounds <= MinRoundsForEffect)
            {
                // Effect expires after fixed number of rounds
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}
