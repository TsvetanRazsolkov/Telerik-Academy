namespace _03.Proxy
{
    using System;
    using System.Collections.Generic;

    public class DungeonBuilderProxy : ITownBuilder
    {
        public const int RequiredCapitolGold = 10000;
        public const int RequiredDragonCaveGold = 15000;
        public const int RequiredDragonCaveSulfur = 20;

        private ITownBuilder realDungeonBuilder;

        public DungeonBuilderProxy()
        {
            this.realDungeonBuilder = new DungeonBuilder();
        }

        public void BuildCapitol(IDictionary<string, int> resources)
        {
            if (resources["gold"] < RequiredCapitolGold)
            {
                Console.WriteLine("Insuffucient gold, cannot build capitol.");
            }
            else
            {
                this.realDungeonBuilder.BuildCapitol(resources);
            }
        }

        public void BuildSeventhLevelUnit(IDictionary<string, int> resources)
        {
            if (resources["gold"] < RequiredDragonCaveGold
                && resources["sulfur"] < RequiredDragonCaveSulfur)
            {
                Console.WriteLine("Insuffucient resources, cannot build dragon cave.");
            }
            else
            {
                this.realDungeonBuilder.BuildSeventhLevelUnit(resources);
            }
        }
    }
}
