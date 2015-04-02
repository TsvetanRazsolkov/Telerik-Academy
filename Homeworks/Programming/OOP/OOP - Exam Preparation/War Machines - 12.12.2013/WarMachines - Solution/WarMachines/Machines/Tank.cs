
namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank, IMachine
    {
        private const double TankInitialHealthPoints = 100;
        private const double DefenseBoost = 30;
        private const double AttackInhibition = 40;


        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, TankInitialHealthPoints, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
        }        

        public bool DefenseMode
        {
            get { return this.defenseMode; }
            private set
            {
                this.defenseMode = value;
            }
        }  

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints += Tank.AttackInhibition;
                this.DefensePoints -= Tank.DefenseBoost;
                this.DefenseMode = false;
            }
            else
            {
                this.AttackPoints -= Tank.AttackInhibition;
                this.DefensePoints += Tank.DefenseBoost;
                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            string defenseMode = this.DefenseMode ? "ON" : "OFF";

            return base.ToString()
                   + string.Format("\r\n *Defense: {0}", defenseMode);
        }
    }
}
