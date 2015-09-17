namespace _02.Decorator
{
    using System;
    using Armors;
    using Weapons;

    public class Example
    {
        public static void Main()
        {
            var jeep = new Truck(70);
            var ship = new Ship(50);

            Console.WriteLine("Simple vehicles:");
            jeep.ShowSpecs();
            Console.WriteLine(new string('-', 40));

            var armoredJeep = new ArmorDecorator(jeep, new HeavyArmor());
            armoredJeep.ShowSpecs();
            Console.WriteLine();

            var armoredHumvee = new WeaponDecorator(armoredJeep, new LightWeapon());
            armoredHumvee.ShowSpecs();
            armoredHumvee.Attack();
        }
    }
}
