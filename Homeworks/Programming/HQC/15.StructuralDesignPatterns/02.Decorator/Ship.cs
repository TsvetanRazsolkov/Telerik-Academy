namespace _02.Decorator
{
    using System;

    public class Ship : MilitaryVehicle
    {
        public Ship(int speed) : base(speed)
        {
        }

        public override void ShowSpecs()
        {
            base.ShowSpecs();
        }
    }
}
