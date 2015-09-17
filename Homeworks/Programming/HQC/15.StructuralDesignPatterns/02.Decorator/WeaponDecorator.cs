namespace _02.Decorator
{
    using Weapons;

    public class WeaponDecorator : MVDecorator
    {
        private readonly int damage;

        public WeaponDecorator(MilitaryVehicle vehicle, Weapon weapon)
            : base(vehicle)
        {
            this.damage = weapon.Damage;
        }

        public void Attack()
        {
            System.Console.WriteLine("Military vehicle attacks and deals {0} damage.", this.damage);
        }

        public override void ShowSpecs()
        {
            base.ShowSpecs();
            System.Console.WriteLine("Damage: " + this.damage);
        }
    }
}
