using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_01.MessagesInABottle
{
    class Program
    {
        static Dictionary<string, char> ciphers = new Dictionary<string, char>();
        static SortedSet<string> results = new SortedSet<string>();
        static StringBuilder tempResult = new StringBuilder();

        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string cipher = Console.ReadLine();
            ParseCiphre(cipher);

            GenerateMessages(message);

            Console.WriteLine(results.Count);
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        private static void GenerateMessages(string message)
        {
            if (message.Length == 0)
            {
                results.Add(tempResult.ToString());
                return;
            }

            foreach (var pair in ciphers)
            {
                string ciph = pair.Key;
                int index = message.IndexOf(ciph);
                if (index == 0)
                {
                    tempResult.Append(pair.Value);
                    GenerateMessages(message.Substring(index + ciph.Length));
                    tempResult.Length--;
                }
            }
        }

        private static void ParseCiphre(string cipher)
        {
            char value = ' ';
            var key = new StringBuilder();

            for (int i = 0; i < cipher.Length; i++)
            {
                value = cipher[i];
                i++;
                while (i < cipher.Length && '0' <= cipher[i] && cipher[i] <= '9')
                {
                    key.Append(cipher[i]);
                    i++;
                }

                i--;
                ciphers.Add(key.ToString(), value);
                key.Clear();
            }
        }
    }
}
