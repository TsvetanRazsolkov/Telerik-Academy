namespace _02.Decorator.Armors
{
    public class HeavyArmor : Armor
    {
        private const int HeavyArmorBonus = 100;
        private const int HeavyArmorSpeedDecrease = 25;

        public HeavyArmor()
            : base(HeavyArmorBonus, HeavyArmorSpeedDecrease)
        {
        }
    }
}