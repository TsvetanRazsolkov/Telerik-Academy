using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Weapon : Item
    {
        private const int WeaponValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, WeaponValue, ItemType.Weapon, location)
        {
        }

    }
}
