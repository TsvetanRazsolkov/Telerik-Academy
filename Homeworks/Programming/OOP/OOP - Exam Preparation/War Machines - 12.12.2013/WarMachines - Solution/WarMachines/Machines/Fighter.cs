
namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter, IMachine
    {
        private const double FighterInitialHealthPoints = 200;
        
        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, FighterInitialHealthPoints, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
        } 

        public bool StealthMode
        {
            get { return this.stealthMode; }
            private set { this.stealthMode = value; }
        }

        public void ToggleStealthMode()
        {
            if (this.StealthMode)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }        

        public override string ToString()
        {
            string stealthMode =  this.StealthMode ? "ON" : "OFF";

            return base.ToString()
                + string.Format("\r\n *Stealth: {0}", stealthMode);
        }
    }
}
