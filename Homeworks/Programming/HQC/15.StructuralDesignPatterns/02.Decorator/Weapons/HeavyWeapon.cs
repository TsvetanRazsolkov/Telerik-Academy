namespace _02.Decorator.Weapons
{
    public class HeavyWeapon : Weapon
    {
        private const int HeavyWeaponDamage = 80;

        public HeavyWeapon() : base(HeavyWeaponDamage)
        {
        }
    }
}