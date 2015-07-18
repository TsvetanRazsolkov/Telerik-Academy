namespace DecreasingAbsoluteDifference
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DecreasingAbsoluteDifference
    {
        public static void Main()
        {
            var results = new List<bool>();

            int numberOfSequences;
            bool isValidInteger = int.TryParse(Console.ReadLine(), out numberOfSequences);
            if (!isValidInteger)
            {
                throw new ArgumentException("Input is not a valid 32 bit integer");
            }

            for (int i = 0; i < numberOfSequences; i++)
            {
                long[] sequence = ParseInputLine();

                long[] sequenceOfAbsoluteDifferences = GetSequenceOfAbsoluteDifferences(sequence);

                bool isDecreasingSequence = DetermineIsSequenceDecreasing(sequenceOfAbsoluteDifferences);

                results.Add(isDecreasingSequence);
            }

            string endResult = string.Join(Environment.NewLine, results);
            Console.WriteLine(endResult);
        }

        private static long[] ParseInputLine()
        {
            string inputLine = Console.ReadLine();
            if (string.IsNullOrEmpty(inputLine))
            {
                throw new ArgumentException("Sequence input cannot be null ot empty string");
            }

            long[] sequence = inputLine.Split(' ')
                                       .Select(number => long.Parse(number))
                                       .ToArray();

            return sequence;
        }

        private static bool DetermineIsSequenceDecreasing(long[] sequence)
        {
            for (int j = 1; j < sequence.Length; j++)
            {
                long differenceBetweenAbsDifferences = sequence[j - 1] - sequence[j];
                if (differenceBetweenAbsDifferences < 0 || differenceBetweenAbsDifferences > 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static long[] GetSequenceOfAbsoluteDifferences(long[] sequence)
        {
            long[] sequenceOfAbsoluteDifferences = new long[sequence.Length - 1];
            for (int j = 1; j < sequence.Length; j++)
            {
                long absoluteDifference = Math.Max(sequence[j], sequence[j - 1]) - Math.Min(sequence[j], sequence[j - 1]);
                sequenceOfAbsoluteDifferences[j - 1] = absoluteDifference;
            }

            return sequenceOfAbsoluteDifferences;
        }
    }
}
