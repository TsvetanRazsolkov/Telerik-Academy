namespace _02.Decorator.Weapons
{
    public class LightWeapon : Weapon
    {
        private const int LightWeaponDamage = 30;

        public LightWeapon() : base(LightWeaponDamage)
        {
        }
    }
}
