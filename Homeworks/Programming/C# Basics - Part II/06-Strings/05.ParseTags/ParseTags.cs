using System;

/* You are given a text. Write a program that changes the text in all regions
surrounded by the tags <upcase> and </upcase> to upper-case.
The tags cannot be nested.
Example: We are living in a <upcase>yellow submarine</upcase>. We don't have
<upcase>anything</upcase> else.
The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
*/

class ParseTags
{
    static void Main()
    {
        // string text = Console.ReadLine();
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        string result = ManipulateString(text);
        Console.WriteLine(result);
    }

    static string ManipulateString(string text)
    {
        int openingTagLength = "<upcase>".Length;
        int closingTagLength = "</upcase>".Length;
        while (true)
        {
            int start = text.IndexOf("<upcase>");
            int end = text.IndexOf("</upcase>");
            if (start < 0 || end < 0)
            {
                break;
            }
            end += closingTagLength;
            string stringToReplace = text.Substring(start, end - start);
            int targetStart = start + openingTagLength;
            int targetLength = end - start - openingTagLength - closingTagLength;
            string targetString = text.Substring(targetStart, targetLength);
            targetString = targetString.ToUpper();
            text = text.Replace(stringToReplace, targetString);
        }
        return text;
    }
}