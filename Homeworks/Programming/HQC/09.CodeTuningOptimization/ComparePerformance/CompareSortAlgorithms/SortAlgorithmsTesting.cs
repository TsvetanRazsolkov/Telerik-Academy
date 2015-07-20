namespace CompareSortAlgorithms
{
    using System;

    public class SortAlgorithmsTesting
    {
        public static void Main()
        {
            string separator = new string('=', 60);

            SortingAlgorithmsTester.TestIntSortingPerformance();
            Console.WriteLine(separator);
            SortingAlgorithmsTester.TestDoubleSortingPerformance();
            Console.WriteLine(separator);
            SortingAlgorithmsTester.TestStringSortingPerformance();
        }
    }
}
