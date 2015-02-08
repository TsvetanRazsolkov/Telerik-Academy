using System;
using System.Text;

class PrintASCIITable
{
    static void Main()
    {
        // Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).

        Console.OutputEncoding = Encoding.Unicode;
        for (int counter = 0; counter <= 255; counter++)
        {
            char symbol = (char)counter;
            string display = string.Empty;
            if (char.IsWhiteSpace(symbol))
            {
                switch (symbol)
                {
                    case '\t':
                        display = "\\t";
                        break;
                    case '\n':
                        display = "\\n";
                        break;
                    case '\v':
                        display = "\\v";
                        break;
                    case '\f':
                        display = "\\f";
                        break;
                    case '\r':
                        display = "\\r";
                        break;
                    case ' ':
                        display = "Space";
                        break;
                }

            }
            else if (char.IsControl(symbol))
            {
                display = "control key";

            }
            else
            {
                display = symbol.ToString();
            }
            Console.WriteLine(counter.ToString().PadRight(10) + display);

        }
    }
}
