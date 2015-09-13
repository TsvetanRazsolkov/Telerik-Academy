namespace _01.AbstractFactory
{
    using Factories;

    public class Example
    {
        public static void Main()
        {
            var bulgarianSoldiersFactory = new BulgarianSoldierFactory();

            var soldierRecruiter = new SoldierRecruitment(bulgarianSoldiersFactory);

            var marinTheMarine = soldierRecruiter.GetMarine();
            marinTheMarine.Fight();

            var peshoThePilot = soldierRecruiter.GetFighterPilot();
            peshoThePilot.Fight();

            var americanSoldiersFactory = new AmericanSoldierFactory();
            System.Console.WriteLine(new string('-', 40));

            soldierRecruiter = new SoldierRecruitment(americanSoldiersFactory);

            var johnTheMarine = soldierRecruiter.GetMarine();
            johnTheMarine.Fight();

            var hohnThePilot = soldierRecruiter.GetFighterPilot();
            hohnThePilot.Fight();
        }
    }
}
