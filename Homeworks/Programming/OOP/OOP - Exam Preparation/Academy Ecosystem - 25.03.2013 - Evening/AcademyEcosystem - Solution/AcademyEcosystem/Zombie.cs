using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int ZombieSize = 0;
        private const int ZombieMeatToGive = 10;

        public Zombie(string name, Point position)
            : base(name, position, ZombieSize)
        {

        }

        public override int GetMeatFromKillQuantity()
        {            
            return ZombieMeatToGive;
        }
    }
}
