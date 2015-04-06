
namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Battles;

    public class DoubleDamage : Specialty
    {
        private const int MaxRoundsForEffect = 10;
        private const int MinRoundsForEffect = 0;

        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds <= MinRoundsForEffect || rounds > MaxRoundsForEffect)
            {
                throw new ArgumentOutOfRangeException("rounds", string.Format("The number of rounds should be greater than {0} and less than {1}",
                    MinRoundsForEffect, MaxRoundsForEffect));
            }
            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }
            if (this.rounds <= MinRoundsForEffect)
            {
                // Effect expires after fixed number of rounds
                return currentDamage;
            }
            else
            {
                this.rounds--;

                return currentDamage * 2;
            }     
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}
