namespace _03.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var biDict = new BiDictionary<string, int, string>();

            biDict.Add("key1", 1, "value11");
            biDict.Add("key1", 2, "value12");
            biDict.Add("key1", 3, "value13");
            biDict.Add("key2", 1, "value21");
            biDict.Add("key2", 2, "value22");
            biDict.Add("key2", 3, "value23");

            Console.WriteLine(biDict.FindByFirstKey("key1"));

            Console.WriteLine(biDict.FindBySecondKey(1));

            Console.WriteLine(biDict.FindByTwoKeys("key1", 3));
        }
    }
}
