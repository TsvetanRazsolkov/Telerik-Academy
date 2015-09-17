namespace _02.Decorator
{
    public abstract class MVDecorator : MilitaryVehicle
    {
        protected MVDecorator(MilitaryVehicle militaryVehicle)
        {
            this.Vehicle = militaryVehicle;
        }

        protected MilitaryVehicle Vehicle { get; private set; }

        public override void ShowSpecs()
        {
            this.Vehicle.ShowSpecs();
        }
    }
}
