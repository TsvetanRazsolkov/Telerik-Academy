namespace LongestString
{
    using System;
    using System.Linq;

    public class LongestString
    {
        static void Main()
        {
            string[] arrOfStrings = new string[]{"1111111111", "1", "10", "100", "1000", "10000",
                                                 "100000", "10000000", "1000000"};

            var result = from str in arrOfStrings
                         orderby str.Length
                         select str;
            Console.WriteLine("Longest string: {0}", result.Last());

            //string result = arrOfStrings.OrderBy(x => x.Length)
            //                            .Last();
            //Console.WriteLine("Longest string: {0}", result);
        }
    }
}
