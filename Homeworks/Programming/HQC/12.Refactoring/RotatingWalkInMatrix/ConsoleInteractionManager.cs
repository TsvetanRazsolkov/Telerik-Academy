namespace RotatingWalkInMatrix
{
    using System;

    public class ConsoleInteractionManager : IInteractionManager
    {
        private const string EnterPositiveNumberMessage = "Enter a positive integer";
        private const string WrongInputMessage = "You haven't entered a correct positive integer";

        public int ReadMatrixSize()
        {
            Console.WriteLine(EnterPositiveNumberMessage);

            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || !Validator.NumberIsInRange(n))
            {
                Console.WriteLine(WrongInputMessage);
                Console.WriteLine(EnterPositiveNumberMessage);
                input = Console.ReadLine();
            }

            return n;
        }

        public void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
