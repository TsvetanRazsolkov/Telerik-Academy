using System;

/* Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
Example:
input	
<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course.
Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
output
<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. 
Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>  */

class ReplaceTags
{
    static void Main()
    {
        string htmlDoc = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        Console.WriteLine(htmlDoc);
        int startIndex = 0;
        int endindex = 0;
        while (true)
        {
            startIndex = htmlDoc.IndexOf("<a href=\"", startIndex);
            endindex = htmlDoc.IndexOf("</a>", endindex);
            if (startIndex == -1 || endindex == -1)
            {
                break;
            }
            else if (startIndex >= 0 && endindex >= 0)
            {
                string substringBeforeTag = htmlDoc.Substring(0, startIndex);
                string substringAfterTag = htmlDoc.Substring(endindex + 4, 
                                            htmlDoc.Length - endindex - 4);
                string substringTag = htmlDoc.Substring(startIndex, endindex + 4 - startIndex);
                substringTag = substringTag.Replace("<a href=\"", "[URL=");
                substringTag = substringTag.Replace("\">", "]");
                substringTag = substringTag.Replace("</a>", "[/URL]");
                htmlDoc = substringBeforeTag + substringTag + substringAfterTag;
            }
            startIndex++;
            endindex++;
        }

        Console.WriteLine(htmlDoc);
    }
}