namespace _01.AbstractFactory
{
    using Factories;
    using Soldiers;

    public class SoldierRecruitment
    {
        private readonly SoldierFactory soldierFactory;

        public SoldierRecruitment(SoldierFactory factory)
        {
            this.soldierFactory = factory;
        }

        public Marine GetMarine()
        {
            return this.soldierFactory.CreateMarine();
        }

        public FighterPilot GetFighterPilot()
        {
            return this.soldierFactory.CreateFighterPilot();
        }
    }
}
