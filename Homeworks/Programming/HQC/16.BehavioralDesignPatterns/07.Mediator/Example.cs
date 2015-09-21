namespace _07.Mediator
{
    using System.Collections.Generic;

    public class Example
    {
        public static void Main()
        {
            var transferMediator = new TransferMediator();

            var barca = new Barcelona(
                "Barcelona FC",
                new List<Player>()
                {
                    new Player("Valery Bojinov", 28, 56, 50, 20000),
                    new Player("Rafinha Alcantara", 20, 68, 80, 50000),
                    new Player("Pesho Igracha", 20, 80, 75, 40000)
                });
            transferMediator.MakeContractWithClub(barca);

            var milan = new Milan(
                "AC Milan",
                new List<Player>()
                {
                    new Player("Carlos Baca", 22, 84, 75, 55000),
                    new Player("Gosho Italianeca", 22, 80, 70, 50000),
                    new Player("Mario Baloteli", 25, 80, 75, 35000)
                });
            transferMediator.MakeContractWithClub(milan);

            milan.SendRequirementsToMediator(50, 10, 12);

            barca.SendRequirementsToMediator(22, 70, 70);

            milan.SendRequirementsToMediator(20, 60, 70);
        }
    }
}
