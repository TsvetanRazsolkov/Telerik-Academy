namespace DefiningClasses_Part1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GSM
    {
        private static GSM iPhone4s = new GSM("IPhone4s", "Apple", 1000M, "Tosho", new Battery("Some model", 200, 14, BatteryType.Li_Ion), 
                                              new Display(3.5, 1000000));
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();

        // Constructor with mandatory arguments
        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }
        
        // Full constructor
        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display) 
            : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public static GSM Iphone4s
        {
            get { return iPhone4s; }
        }

        public string  Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The GSM model cannot be null or empty.");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The GSM manufacturer cannot be null or empty.");
                }

                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or zero, sadly.");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public List<Call> CallHistory
        {
            get { return new List<Call>(this.callHistory); }
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal CalculateTotalCallPrice(decimal callPricePerMinute)
        {
            decimal totalCallsDurationInMinutes =  this.CallHistory.Sum(x => x.CallDuration/60M);
            decimal totalPrice = callPricePerMinute * totalCallsDurationInMinutes;
            return totalPrice;
        }

        public string GetCallHistory()
        {
            StringBuilder result = new StringBuilder();

            if (this.CallHistory.Count > 0)
            {
                foreach (var call in this.CallHistory)
                {
                    result.AppendLine(call + Environment.NewLine);
                }
            }
            else
            {
                throw new NullReferenceException("Call history is empty.");
            }

            return result.ToString();
        }

        public override string ToString()
        {
            StringBuilder characteristics = new StringBuilder();

            characteristics.AppendLine("Model: " + this.Model);
            characteristics.AppendLine("Manufacturer: " + this.Manufacturer);
            if (this.Price != null)
            {
                characteristics.AppendLine("Price: " + this.Price);
            }
            if (this.Owner != null)
            {
                characteristics.AppendLine("Owner: " + this.Owner);
            }
            if (this.Battery != null)
            {
                characteristics.AppendLine(this.Battery.ToString());
            }
            if (this.Display != null)
            {
                characteristics.Append(this.Display.ToString());
            }
            
            return characteristics.ToString();
        }
    }
}
