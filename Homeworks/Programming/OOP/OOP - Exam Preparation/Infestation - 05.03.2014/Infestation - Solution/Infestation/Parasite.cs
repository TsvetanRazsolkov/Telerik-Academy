using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Parasite : Infestor
    {
        private const int ParasiteBasePower = 1;
        private const int ParasiteBaseHealth = 1;
        private const int ParasiteBaseAggression = 1;
        private const UnitClassification ParasiteUnitType = UnitClassification.Biological;

        public Parasite(string id)
            : base(id, ParasiteUnitType, ParasiteBaseHealth, ParasiteBasePower, ParasiteBaseAggression)
        {
        }        
    }
}
