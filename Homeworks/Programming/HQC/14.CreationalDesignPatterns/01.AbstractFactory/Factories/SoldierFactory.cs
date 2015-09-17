namespace _01.AbstractFactory.Factories
{
    using Soldiers;

    public abstract class SoldierFactory
    {
        public abstract Marine CreateMarine();

        public abstract FighterPilot CreateFighterPilot();
    }
}
