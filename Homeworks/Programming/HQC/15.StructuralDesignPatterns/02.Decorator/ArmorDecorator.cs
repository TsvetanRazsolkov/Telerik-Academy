namespace _02.Decorator
{
    using Armors;

    public class ArmorDecorator : MVDecorator
    {
        private readonly int defense;

        public ArmorDecorator(MilitaryVehicle vehicle, Armor armor)
            : base(vehicle)
        {
            this.Vehicle.Speed -= armor.SpeedDecrease;
            this.defense = armor.ArmorBonus;
        }

        public override void ShowSpecs()
        {
           base.ShowSpecs();
           System.Console.WriteLine("Defense: " + this.defense);
        }
    }
}