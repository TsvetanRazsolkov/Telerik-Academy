using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Съвпадение
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            int maxLength = Solve(start, end);

            Console.WriteLine(maxLength);
        }

        private static int Solve(string start, string end)
        {
            int left = 0;
            int right = Math.Min(start.Length, end.Length) + 1;

            Hash.ComputePowers(Math.Min(start.Length, end.Length));

            while (left < right)
            {
                int middle = (left + right) / 2;

                bool isMatch = Check(start, end, middle);
                if (isMatch)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left - 1;
        }

        private static bool Check(string start, string end, int length)
        {
            var hash1 = new Hash(start.Substring(0, length));

            HashSet<ulong> hashes1 = new HashSet<ulong>();
            HashSet<ulong> hashes2 = new HashSet<ulong>();
            hashes1.Add(hash1.Value1);
            hashes2.Add(hash1.Value2);

            for (int i = 0; i < start.Length - length; i++)
            {
                hash1.Add(start[length + i]);
                hash1.Remove(start[i], length);

                hashes1.Add(hash1.Value1);
                hashes2.Add(hash1.Value2);
            }

            var hash2 = new Hash(end.Substring(0, length));
            if (hashes1.Contains(hash2.Value1) && hashes2.Contains(hash2.Value2))
            {
                return true;
            }

            for (int i = 0; i < end.Length - length; i++)
            {
                hash2.Add(end[length + i]);
                hash2.Remove(end[i], length);

                if (hashes1.Contains(hash2.Value1) && hashes2.Contains(hash2.Value2))
                {
                    return true;
                }
            }

            return false;
        }
    }

    class Hash
    {
        // bases and MODs should be prime numbers
        private const ulong BASE1 = 127;
        private const ulong BASE2 = 257;
        private const ulong MOD = 1000000033;

        private static ulong[] powers1;
        private static ulong[] powers2;

        public Hash(string str)
        {
            this.Value1 = 0;
            this.Value2 = 0;

            foreach (char c in str)
            {
                this.Add(c);
            }
        }

        public ulong Value1 { get; private set; }

        public ulong Value2 { get; set; }

        public static void ComputePowers(int n)
        {
            powers1 = new ulong[n + 1];
            powers2 = new ulong[n + 1];
            powers1[0] = 1;
            powers2[0] = 1;

            for (int i = 0; i < n; i++)
            {
                powers1[i + 1] = powers1[i] * BASE1 % MOD;
                powers2[i + 1] = powers2[i] * BASE2 % MOD;
            }
        }

        public void Add(char c)
        {
            this.Value1 = (this.Value1 * BASE1 + c) % MOD;
            this.Value2 = (this.Value2 * BASE2 + c) % MOD;
        }

        public void Remove(char c, int n)
        {
            this.Value1 = (MOD + this.Value1 - powers1[n] * c % MOD) % MOD;
            this.Value2 = (MOD + this.Value2 - powers2[n] * c % MOD) % MOD;
        }
    }
}
