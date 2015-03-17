/* Implement an extension method Substring(int index, int length) for the class StringBuilder
that returns new StringBuilder and has the same functionality as Substring in the class String. */
namespace StringBuilderSubstring
{
    using System;
    using System.Text;

    public class SBExtensionTest
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append((char)(i + 'A'));
            }
            Console.WriteLine("Original stringbuilder: " + sb);

            StringBuilder subStr = sb.Substring(0, 4);
            Console.WriteLine("Substring from the stringbuilder from index 0 with length 4: " + subStr);

            // The following will throw an exception:
            //StringBuilder other = sb.Substring(4, 12);
            //Console.WriteLine(other);
        }
    }
}
