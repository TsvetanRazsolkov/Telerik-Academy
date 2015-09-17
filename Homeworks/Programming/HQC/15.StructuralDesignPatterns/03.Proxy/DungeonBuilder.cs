namespace _03.Proxy
{
    using System;
    using System.Collections.Generic;

    public class DungeonBuilder : ITownBuilder
    {
        public void BuildCapitol(IDictionary<string, int> resources)
        {
            Console.WriteLine("Building capitol, earning 4 000 gold per day.");
        }

        public void BuildSeventhLevelUnit(IDictionary<string, int> resources)
        {
            Console.WriteLine("Building black dragons cave.");
        }
    }
}
