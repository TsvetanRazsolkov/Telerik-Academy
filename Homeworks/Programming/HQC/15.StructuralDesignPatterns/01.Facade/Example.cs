namespace _01.Facade
{
    using System;

    public class Example
    {
        public static void Main()
        {
            var buildingTrader = new BuildingSeller();

            buildingTrader.InitiateTrade()
                          .BuildBuilding()
                          .Sell();
        }
    }
}
