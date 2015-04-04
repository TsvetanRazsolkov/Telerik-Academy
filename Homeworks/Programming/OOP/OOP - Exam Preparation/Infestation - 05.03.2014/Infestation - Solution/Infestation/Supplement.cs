using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class Supplement : ISupplement // The supplements can be in a separate folder, but solution might be rejected from BGCoder;
    {
        public Supplement(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {            
        }

        public int PowerEffect { get; protected set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; protected set; }
    }
}
