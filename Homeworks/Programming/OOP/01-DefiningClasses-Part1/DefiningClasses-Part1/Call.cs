namespace DefiningClasses_Part1
{
    using System;

    public class Call
    {
        private DateTime dateTime;
        private string dialedNumber;
        private int callDuration;

        public Call(DateTime time, string dialedNumber, int duration)
        {
            this.DateTime = time;
            this.DialedNumber = dialedNumber;
            this.CallDuration = duration;
        }

        public DateTime DateTime
        {
            get { return this.dateTime; }
            set { this.dateTime = value; }
        }

        public string DialedNumber
        {
            get { return this.dialedNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phone number cannot be empty or null.");
                }
                this.dialedNumber = value; 
            }
        }

        public int CallDuration
        {
            get { return this.callDuration; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Call duration must be positive or zero.");
                }
                this.callDuration = value;
            }
        }

        public override string ToString()
        {
            string callInformation = string.Format("Date and time of call: {0}\nDialed number: {1}\nCall duration: {2}sec",
                this.DateTime, this.DialedNumber, this.CallDuration);
            
            return callInformation;
        }
    }
}
