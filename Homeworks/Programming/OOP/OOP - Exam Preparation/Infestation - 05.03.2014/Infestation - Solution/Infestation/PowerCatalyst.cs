using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class PowerCatalyst : Supplement, ISupplement
    {
        private const int SupplementPowerEffect = 3;

        public PowerCatalyst() : base(SupplementPowerEffect, 0, 0)
        {
        }
    }
}
