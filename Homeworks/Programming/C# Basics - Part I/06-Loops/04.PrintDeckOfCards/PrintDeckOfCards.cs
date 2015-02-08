using System;
using System.Text;

class PrintDeckOfCards
{
    static void Main()
    {
        // Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers). The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).The card faces should start from 2 to A.Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement. Note: You may use the suit symbols instead of text.

        Console.OutputEncoding = Encoding.Unicode;
        for (int card = 2; card < 15; card++)
        {
            for (int suit = 0; suit < 4; suit++)
            {
                if (card == 11)
                {
                    char cardSymbol = 'J';
                    switch (suit)
                    {
                        case 0:
                            Console.Write("{0}{1} ", cardSymbol, '\u2660');
                            break;
                        case 1:
                            Console.Write("{0}{1} ", cardSymbol, '\u2665');
                            break;
                        case 2:
                            Console.Write("{0}{1} ", cardSymbol, '\u2666');
                            break;
                        case 3:
                            Console.Write("{0}{1} ", cardSymbol, '\u2663');
                            break;
                        default:
                            break;
                    }
                }
                else if (card == 12)
                {
                    char cardSymbol = 'Q';
                    switch (suit)
                    {
                        case 0:
                            Console.Write("{0}{1} ", cardSymbol, '\u2660');
                            break;
                        case 1:
                            Console.Write("{0}{1} ", cardSymbol, '\u2665');
                            break;
                        case 2:
                            Console.Write("{0}{1} ", cardSymbol, '\u2666');
                            break;
                        case 3:
                            Console.Write("{0}{1} ", cardSymbol, '\u2663');
                            break;
                        default:
                            break;
                    }
                }
                else if (card == 13)
                {
                    char cardSymbol = 'K';
                    switch (suit)
                    {
                        case 0:
                            Console.Write("{0}{1} ", cardSymbol, '\u2660');
                            break;
                        case 1:
                            Console.Write("{0}{1} ", cardSymbol, '\u2665');
                            break;
                        case 2:
                            Console.Write("{0}{1} ", cardSymbol, '\u2666');
                            break;
                        case 3:
                            Console.Write("{0}{1} ", cardSymbol, '\u2663');
                            break;
                        default:
                            break;
                    }
                }
                else if (card == 14)
                {
                    char cardSymbol = 'A';
                    switch (suit)
                    {
                        case 0:
                            Console.Write("{0}{1} ", cardSymbol, '\u2660');
                            break;
                        case 1:
                            Console.Write("{0}{1} ", cardSymbol, '\u2665');
                            break;
                        case 2:
                            Console.Write("{0}{1} ", cardSymbol, '\u2666');
                            break;
                        case 3:
                            Console.Write("{0}{1} ", cardSymbol, '\u2663');
                            break;
                        default:
                            break;
                    }
                }
                else
                {

                    switch (suit)
                    {
                        case 0:
                            Console.Write("{0} {1}", card, '\u2660');
                            break;
                        case 1:
                            Console.Write("{0} {1}", card, '\u2665');
                            break;
                        case 2:
                            Console.Write("{0} {1}", card, '\u2666');
                            break;
                        case 3:
                            Console.Write("{0} {1}", card, '\u2663');
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}