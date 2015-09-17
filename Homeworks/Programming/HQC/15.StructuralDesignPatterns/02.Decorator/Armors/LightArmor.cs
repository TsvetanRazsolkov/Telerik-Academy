namespace _02.Decorator.Armors
{
    public class LightArmor : Armor
    {
        private const int LightArmorBonus = 30;
        private const int LightArmorSpeedDecrease = 10;

        public LightArmor() : base(LightArmorBonus, LightArmorSpeedDecrease)
        {
        }
    }
}
