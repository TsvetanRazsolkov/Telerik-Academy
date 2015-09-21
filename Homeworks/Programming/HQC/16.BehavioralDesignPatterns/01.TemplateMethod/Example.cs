namespace _01.TemplateMethod
{
    using System;

    public class Example
    {
        public static void Main()
        {
            var valeri = new BulgarianFootballPlayer("Valeri", "wiskey and aulin");
            var tomas = new GermanFootballPlayer("Tomas");

            Console.WriteLine("German player {0} footballing days:", tomas.Name);
            tomas.PlayFootball();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Bulgarian player {0} footballing days:", valeri.Name);
            valeri.PlayFootball();
        }
    }
}
