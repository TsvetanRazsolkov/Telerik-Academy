
namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IPilot pilot;
        private IList<string> targets;

        public Machine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pilot name can not be null, empty string or a white space.");
                }
                this.name = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Health points can not be negative."); // maybe not;
                }
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Attack points can not be less than zero.");// maybe not;
                }
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Defense points can not be less than zero.");// maybe not;
                }
                this.defensePoints = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Can not engage a machine with a NULL as pilot value.");
                }
                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
            protected set
            {
                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentException("Target can not be empty string or null.");
            }
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            string machineName = this.Name;
            string machineType = this.GetType().Name;
            string machineHealth = this.HealthPoints.ToString();
            string machineAttack = this.AttackPoints.ToString();
            string machineDefense = this.DefensePoints.ToString();
            var targetsList = this.Targets;

            output.AppendFormat("- {0}", machineName);
            output.AppendFormat("\r\n *Type: {0}", machineType);
            output.AppendFormat("\r\n *Health: {0}", machineHealth);
            output.AppendFormat("\r\n *Attack: {0}", machineAttack);
            output.AppendFormat("\r\n *Defense: {0}", machineDefense);
            output.AppendFormat("\r\n *Targets: {0}",
                this.Targets.Count == 0 ? "None" : string.Join(", ", targetsList));

            return output.ToString();
        }
    }
}
