using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class AggressionCatalyst : Supplement, ISupplement
    {
        private const int SupplementAggressionEffect = 3;

        public AggressionCatalyst() : base(0, 0, SupplementAggressionEffect)
        {
        }       
    }
}
