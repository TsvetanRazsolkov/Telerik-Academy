using System;

    class BitsExchangeAdvanced
    {
        static void Main()
        {
            // Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer. The first and the second sequence of bits may not overlap.

            Console.Write("Enter a positive 32-bit integer number and press ENTER:");
            uint number;
            bool numberCheck = uint.TryParse(Console.ReadLine(), out number);
            string numberbinary = Convert.ToString(number, 2).PadLeft(32, '0');

            Console.Write("Enter postitive position number p and press ENTER:");
            byte p;
            bool pCheck = byte.TryParse(Console.ReadLine(), out p);

            Console.Write("Enter positive position number q and press ENTER:");
            byte q;
            bool qCheck = byte.TryParse(Console.ReadLine(), out q);

            Console.Write("Enter positive number k and press ENTER:");
            byte k;
            bool kCheck = byte.TryParse(Console.ReadLine(), out k);

            if (numberCheck && pCheck && qCheck && kCheck && ((p + k - 1) < 32) && ((q + k - 1) < 32) && ((p + k < q) ||(q + k < p)))
            {
                Console.WriteLine("Number n = {0}", number);
                Console.WriteLine("p={0}\nq={1}\nk={2}", p, q, k);
                Console.WriteLine("Binary representation of n: {0}", numberbinary);

                for (int P = p, Q = q; P < (p + k) && Q < (q + k); P++, Q++)
                {
                    int bitP = (int)((number >> P) & 1);
                    int bitQ = (int)((number >> Q) & 1);
                    number = (uint)(number & (~(1 << P)) | (bitQ << P));
                    number = (uint)(number & (~(1 << Q)) | (bitP << Q));      
                }
                string resultBinary = Convert.ToString(number, 2).PadLeft(32, '0');
                Console.WriteLine("Binary result: {0}", resultBinary);
                Console.WriteLine("Result = {0}", number);
                
            }
            else if (((p + k - 1) >= 32) || ((q + k - 1) >= 32))
            {
                Console.WriteLine("Out of range.");
            }
            else if ((p + k >= q) ||(q + k >= p))
            {
                Console.WriteLine("Overlapping");
            }
        }
    }
