namespace BitArray64
{
    using System;

    public class BitArray64Test
    {
        public static readonly string separator = new string('-', Console.WindowWidth);

        public static void Main()
        {
            BitArray64 firstArr = new BitArray64(7);
            Console.WriteLine("Numeric value of the bit array = {0}", firstArr.NumValue);
            Console.WriteLine("  Indexer test: ");
            Console.WriteLine("Bit at position 2 = {0}", firstArr[2]);
            firstArr[3] = 1;
            Console.WriteLine("Numeric value of the bit array after setting bit[3] to 1 = {0}",
                                                                                 firstArr.NumValue);
            Console.Write(separator);

            BitArray64 secondArr = new BitArray64(465889955545565);
            BitArray64 thirdArr = new BitArray64(15);

            Console.WriteLine("  Test Equals() and ==, != operators: ");
            Console.WriteLine(firstArr.Equals(secondArr));
            Console.WriteLine(firstArr == secondArr);
            Console.WriteLine(firstArr.Equals(thirdArr));
            Console.WriteLine(firstArr == thirdArr);
            Console.Write(separator);

            Console.WriteLine(" Testing enumerator on bit array with numeric value {0}: ", firstArr.NumValue);
            foreach (var bit in firstArr)
            {
                Console.Write(bit + "  ");
            }
            Console.WriteLine();
            Console.Write(separator);
        }
    }
}
