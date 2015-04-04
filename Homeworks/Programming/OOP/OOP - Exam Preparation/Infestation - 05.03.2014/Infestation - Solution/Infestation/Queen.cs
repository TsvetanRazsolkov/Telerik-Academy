using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : Infestor
    {
        private const int QueenBasePower = 1;
        private const int QueenBaseHealth = 30;
        private const int QueenBaseAggression = 1;
        private const UnitClassification QueenUnitType = UnitClassification.Psionic;

        public Queen(string id)
            : base(id, QueenUnitType, QueenBaseHealth, QueenBasePower, QueenBaseAggression)
        {
        }
    }
}
