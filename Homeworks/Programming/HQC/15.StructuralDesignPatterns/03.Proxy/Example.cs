namespace _03.Proxy
{
    using System.Collections.Generic;

    public class Example
    {
        public static void Main()
        {
            Player pesho = new Player("Pesho", new Dictionary<string, int>() { { "gold", 100 }, { "sulfur", 30 } });

            Player gosho = new Player("Gosho", new Dictionary<string, int>() { { "gold", 15000 }, { "sulfur", 32 } });

            var proxyDungeonBuilder = new DungeonBuilderProxy();

            proxyDungeonBuilder.BuildCapitol(pesho.Resources);

            proxyDungeonBuilder.BuildSeventhLevelUnit(gosho.Resources);
        }
    }
}
