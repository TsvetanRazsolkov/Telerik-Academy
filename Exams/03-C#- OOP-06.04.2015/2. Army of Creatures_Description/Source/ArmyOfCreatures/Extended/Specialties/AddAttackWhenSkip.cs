
namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Battles;

    public class AddAttackWhenSkip : Specialty
    {
        private const int MaxAttackToAdd = 10;
        private const int MinAttackToAdd = 1;

        private readonly int attackToAdd;

        public AddAttackWhenSkip(int attackToAdd)
        {
            if (attackToAdd < MinAttackToAdd || attackToAdd > MaxAttackToAdd)
            {
                throw new ArgumentOutOfRangeException("attackToAdd", string.Format("attackToAdd should be between {0} and {1}, inclusive",
                    MinAttackToAdd, MaxAttackToAdd));
            }

            this.attackToAdd = attackToAdd;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.attackToAdd;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.attackToAdd);
        }
    }
}
