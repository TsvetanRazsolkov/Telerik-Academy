namespace _03.Memento
{
    using System;

    public class Example
    {
        public static void Main()
        {
            var memory = new GameMemory();
            var pesho = new Player("Pesho", 0);

            Console.WriteLine("Player starts the game:");
            Console.WriteLine("{0} - {1} points", pesho.Name, pesho.Points);

            memory.Saves.Add("first save", pesho.Save());

            // Pesho plays for a while and gets some points
            pesho.Points += 20;

            memory.Saves.Add("second save", pesho.Save());

            Console.WriteLine("Player doing well: ");
            Console.WriteLine("{0} - {1} points", pesho.Name, pesho.Points);

            // Pesho plays and loses points
            pesho.Points -= 15;

            Console.WriteLine("Player not doing so well: ");
            Console.WriteLine("{0} - {1} points", pesho.Name, pesho.Points);

            pesho.Load(memory.Saves["second save"]);

            Console.WriteLine("Player loading a better state: ");
            Console.WriteLine("{0} - {1} points", pesho.Name, pesho.Points);
        }
    }
}
