
namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.Machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pilot name can not be null, empty string or a white space.");
                }
                this.name = value;
            }
        }

        public IList<IMachine> Machines
        {
            get { return this.machines; }
            private set { this.machines = value; }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("Machine can not be null.");
            }
            this.Machines.Add(machine); 
        }

        public string Report()
        {
            var result = new StringBuilder();

            string pilotName = this.Name;
            string machinesCount = this.Machines.Count > 0 ? this.Machines.Count.ToString() : "no";
            string wordForMachine = this.Machines.Count == 1 ? "machine" : "machines";

            result.AppendFormat("{0}", pilotName);
            result.AppendFormat(" - {0}", machinesCount);
            result.AppendFormat(" {0}", wordForMachine);

            if (this.Machines.Count > 0)
            {
                var sortedMachines = this.Machines.OrderBy(m => m.HealthPoints)
                                                  .ThenBy(m => m.Name);
                foreach (var machine in sortedMachines)
                {
                    result.AppendFormat("\r\n{0}", machine.ToString());
                }
            }
            return result.ToString();
        }
    }
}
