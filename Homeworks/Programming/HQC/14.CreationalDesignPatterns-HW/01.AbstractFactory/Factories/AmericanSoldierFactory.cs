namespace _01.AbstractFactory.Factories
{
    using Soldiers;

    public class AmericanSoldierFactory : SoldierFactory
    {
        public override Marine CreateMarine()
        {
            return new Marine(100, 100);
        }

        public override FighterPilot CreateFighterPilot()
        {
            return new FighterPilot(300, 150);
        }
    }
}
