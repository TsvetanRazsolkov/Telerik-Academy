using System;
using System.Text;

/* Write a program that encodes and decodes a string using given encryption key 
(cipher).  The key consists of a sequence of characters.
The encoding/decoding is done by performing XOR (exclusive or) operation over the 
first letter of the string with the first of the key, the second – with the second, 
etc. When the last key character is reached, the next is the first.  */

class EncodeDecode
{
    static void Main()
    {
        Console.Write("Enter some text: ");
        string text = Console.ReadLine();
        Console.Write("Enter encryption key: ");
        string cipher = Console.ReadLine();

        string encoded = EncodeAndDecode(text, cipher);
        Console.WriteLine("Encoded text: " + encoded);
        string decoded = EncodeAndDecode(encoded, cipher);
        Console.WriteLine("Decoded text: " + decoded);
    }

    static string EncodeAndDecode(string text, string cipher)
    {
        var sb = new StringBuilder();
        int cipherIndex = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (cipherIndex > cipher.Length - 1)
            {
                cipherIndex = 0;
            }
            sb.Append((char)(text[i] ^ cipher[cipherIndex]));
            cipherIndex++;
        }
        return sb.ToString();
    }
}