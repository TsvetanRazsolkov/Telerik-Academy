
/*Write a program to calculate the "Minimum Edit Distance" (MED) between two words.
MED(x, y) is the minimal sum of costs of edit operations used to transform x to y.

Sample costs:
cost (replace a letter) = 1
cost (delete a letter) = 0.9
cost (insert a letter) = 0.8
Example:
x = "developer", y = "enveloped" → cost = 2.7
delete ‘d’: "developer" → "eveloper", cost = 0.9
insert ‘n’: "eveloper" → "enveloper", cost = 0.8
replace ‘r’ → ‘d’: "enveloper" → "enveloped", cost = 1*/
namespace _02.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private const double ReplacementCost = 1.0;
        private const double DeletionCost = 0.9;
        private const double InsertionCost = 0.8;

        private static string startWord;
        private static string targetWord;

        private static double[,] costsTable;

        public static void Main()
        {
            startWord = "developer";
            targetWord = "enveloped";
            //// Or 
            //startWord = Console.ReadLine();
            //targetWord = Console.ReadLine();

            costsTable = new double[startWord.Length + 1,targetWord.Length + 1];
            FillCostsTable();

            var med = costsTable[startWord.Length, targetWord.Length];

            Console.WriteLine("x = {0}, y = {1} -> cost = {2}",startWord, targetWord, costsTable[startWord.Length,targetWord.Length]);
        }

        private static void FillCostsTable()
        {
            //base case - from empty string to empty string - no cost
            costsTable[0, 0] = 0;

            //The first row - from empty start to produce full target you must insert targetWord.Length times:
            for (int i = 0; i < costsTable.GetLength(1); i++)
            {
                costsTable[0, i] = i * InsertionCost;
            }

            //The second row - from full start to produce empty target you must delete startWord.Length times:
            for (int i = 0; i < costsTable.GetLength(0); i++)
            {
                costsTable[i, 0] = i * DeletionCost;
            }

            for (int i = 0; i < startWord.Length; i++)
            {
                for (int j = 0; j < targetWord.Length; j++)
                {
                    var replaceCost = startWord[i] == targetWord[j] ? 0 : ReplacementCost;

                    //the current cell which is diagonally up and left to the the one we want to fill
                    var replace = costsTable[i, j] + replaceCost;

                    //the top cell to the the one we want to fill(from position i+1,j+1 top is i,j + 1)
                    var delete = costsTable[i, j + 1] + DeletionCost;

                    //the left cell to the the one we want to fill(from position i+1,j+1 left is i + 1,j)
                    var insert = costsTable[i + 1, j] + InsertionCost;

                    costsTable[i + 1, j + 1] = Math.Min(Math.Min(replace, delete), insert);
                }
            }
        }
    }
}
