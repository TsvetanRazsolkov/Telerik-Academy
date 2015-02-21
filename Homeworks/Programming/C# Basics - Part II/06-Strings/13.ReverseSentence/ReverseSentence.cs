using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Write a program that reverses the words in given sentence.
Example:

input	                                output
C# is not C++, not PHP and not Delphi!	Delphi not and PHP, not C++ not is C#!
*/

class ReverseSentence
{
    static string[] punctuation = { ",", ".", "!", "?", ";" };
    static void Main()
    {
        //Console.Write("Enter some text: ");
        //string text = Console.ReadLine();
        string text = "C# is not C++, not PHP and not Delphi!";
                 
        StringBuilder sb = new StringBuilder();

        foreach (char item in text)
        {
            if (char.IsLetter(item) || !punctuation.Contains(Convert.ToString(item)))
            {
                sb.Append(item);
            }
            else
            {
                sb.Append(' ');
                sb.Append(item);
            }
        }
        string[] textAsArray = sb.ToString().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

        List<string> result = new List<string>();
        for (int i = textAsArray.Length - 1; i >= 0; i--)
        {
            if (!punctuation.Contains(textAsArray[i]))
            {
                result.Add(textAsArray[i]);
            }
        }
                
        for (int i = 0; i < textAsArray.Length; i++)
        {
            if (punctuation.Contains(textAsArray[i]))
            {
                result.Insert(i, textAsArray[i]);
            }
        }

        for (int i = 1; i < result.Count; i++)
        {
            if (result[i - 1] != " ")
            {
                if (!punctuation.Contains(result[i].ToString()))
                {
                    result.Insert(i, " ");
                }
            }
        }
        Console.WriteLine(text);
        foreach (string word in result)
        {
            Console.Write(word);
        }
        Console.WriteLine();
    }
}