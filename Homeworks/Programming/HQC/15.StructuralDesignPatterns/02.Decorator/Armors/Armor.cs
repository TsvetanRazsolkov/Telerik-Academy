namespace _02.Decorator.Armors
{
    public abstract class Armor
    {
        public Armor(int armorBonus, int speedDecrease)
        {
            this.ArmorBonus = armorBonus;
            this.SpeedDecrease = speedDecrease;
        }

        public int ArmorBonus { get; private set; }

        public int SpeedDecrease { get; private set; }
    }
}
