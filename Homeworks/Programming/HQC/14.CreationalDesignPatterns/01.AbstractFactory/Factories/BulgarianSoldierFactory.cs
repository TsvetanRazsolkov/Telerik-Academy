namespace _01.AbstractFactory.Factories
{
    using Soldiers;

    public class BulgarianSoldierFactory : SoldierFactory
    {
        public override Marine CreateMarine()
        {
            return new Marine(75, 80);
        }

        public override FighterPilot CreateFighterPilot()
        {
            return new FighterPilot(200, 110);
        }
    }
}
