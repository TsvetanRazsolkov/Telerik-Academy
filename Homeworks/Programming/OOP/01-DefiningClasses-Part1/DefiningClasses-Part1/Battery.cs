namespace DefiningClasses_Part1
{
    using System;

    public class Battery
    {
        private string model;
        private double? hoursIdle;
        private double? hoursTalk;
        private BatteryType? batteryType;

        // Empty constructor, all characteristic will be null
        public Battery()
        {

        }

        // Full constructor
        public Battery(string model, double hoursIdle, double hoursTalk, BatteryType batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The idle hours characteristic of a battery cannot be negative.");
                }

                this.hoursIdle = value;
            }
        }

        public double? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The talk hours characteristic of a battery cannot be negative.");
                }

                this.hoursTalk = value;
            }
        }

        public BatteryType? BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        public override string ToString()
        {
            string characteristics = string.Format("Battery model: {0}, Battery type: {1}, Hours idle: {2}, Hours talk: {3}", this.Model,
                this.BatteryType, this.HoursIdle, this.HoursTalk);

            return characteristics;
        }
    }
}
