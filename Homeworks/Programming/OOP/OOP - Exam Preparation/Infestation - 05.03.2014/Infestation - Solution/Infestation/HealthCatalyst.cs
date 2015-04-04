using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HealthCatalyst : Supplement, ISupplement
    {
        private const int SupplementHealthEffect = 3;

        public HealthCatalyst() : base(0, SupplementHealthEffect, 0)
        {
        }
    }
}
