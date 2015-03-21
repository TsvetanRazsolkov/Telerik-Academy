namespace StudentsAndWorkers
{
    using System;

    public class Worker : Human
    {
        private const int workDaysPerWeek = 5;

        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Man, you're f****d - salary should not be less than zero.");
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if (value > 10 || value <= 0)
                {
                    throw new ArgumentException("Work hours per day must not exceed 10 and can not be less than zero.");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal HourWage()
        {
            decimal hourWage = 0.0M;

            decimal totalWorkHoursPerWeek = (decimal)(this.WorkHoursPerDay * workDaysPerWeek);

            hourWage = this.WeekSalary / totalWorkHoursPerWeek;

            return hourWage;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, Hourly wage: {2:C}\nWeek salary: {3:C}, Daily work hours: {4}",
                this.FirstName, this.LastName, this.HourWage(), this.WeekSalary, this.WorkHoursPerDay);
        }
    }
}
