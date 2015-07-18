namespace RefactorIfStatements
{
    using System;

    public class RefactorIfStatements
    {
        public const int MinX = 0;
        public const int MaxX = 10;
        public const int MinY = 0;
        public const int MaxY = 10;

        public static void Main()
        {
            // First if-statement to refactor:
            // Potato potato;
            ////... 
            // if (potato != null)
            //    if (!potato.HasNotBeenPeeled && !potato.IsRotten)
            //        Cook(potato);
            Potato potato = new Potato();
            if (potato == null)
            {
                throw new NullReferenceException("Potato is null. Cannot cook null.");
            }
            else
            {
                if (potato.IsPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
                else
                {
                    Console.WriteLine("Cannot cook potato - not peeled or rotten");
                }
            }

            // Second if-statement to refactor:
            // if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
            // {
            //    VisitCell();
            // }
            int x = 1;
            int y = 2;
            bool shouldVisitCell = true;
            bool isValueInRange = IsInRange(x, MinX, MaxX) && IsInRange(y, MinY, MaxY);

            if (isValueInRange && shouldVisitCell)
            {
                VisitCell();
            }
        }

        private static bool IsInRange(int number, int minValue, int maxValue)
        {
            bool inRange = minValue <= number && number <= maxValue;

            return inRange;
        }

        private static void VisitCell()
        {
            Console.WriteLine("Visitting cell...");
        }

        private static void Cook(Potato potato)
        {
            Console.WriteLine("Cooking tators...");
        }
    }
}
