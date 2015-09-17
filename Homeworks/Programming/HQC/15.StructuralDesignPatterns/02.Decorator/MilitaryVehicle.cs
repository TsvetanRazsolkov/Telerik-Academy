namespace _02.Decorator
{
    using System;

    public abstract class MilitaryVehicle
    {
        public MilitaryVehicle()
        {
        }

        public MilitaryVehicle(int speed)
        {
            this.Speed = speed;
        }

        public int Speed { get; set; }

        public virtual void ShowSpecs()
        {
            Console.WriteLine("Speed: " + this.Speed);
        }
    }
}
