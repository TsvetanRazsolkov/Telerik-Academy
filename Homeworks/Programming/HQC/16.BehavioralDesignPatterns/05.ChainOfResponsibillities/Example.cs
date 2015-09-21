namespace _05.ChainOfResponsibillities
{
    public class Example
    {
        public static void Main()
        {
            GalacticHero hanSolo = new RebelFighter("Han Solo", 50);
            GalacticHero obiWan = new Jedi("Obi-Wan Kenobi", 75);
            GalacticHero yoda = new MasterJedi("Master Yoda", 100);

            hanSolo.SetSuccessor(obiWan);
            obiWan.SetSuccessor(yoda);

            hanSolo.DefeatVillain(new Villain("Boba Fett", 50));
            hanSolo.DefeatVillain(new Villain("Darth Maul", 70));
            hanSolo.DefeatVillain(new Villain("Darth Vader", 90));
            hanSolo.DefeatVillain(new Villain("Lord Sidius", 120));
        }
    }
}
