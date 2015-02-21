using System;
using System.Text;

/* Write a program that extracts from given HTML file its title (if available), and its body text
without the HTML tags.
Example input:
<html>
  <head><title>News</title></head>
  <body><p><a href="http://academy.telerik.com">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skilful .NET software engineers.</p></body>
</html>
Output:
Title: News
Text: Telerik Academy aims to provide free real-world practical training for young people who 
want to turn into skilful .NET software engineers.   */

class ExtraxtTextFromHTML
{
    const string openingTitleTag = "<title>";
    const string closingTitleTag = "</title>";
    const string openingBodyTag = "<body>";
    const string closingBodyTag = "</body>";

    static void Main()
    {
        string text = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.</p></body></html>";
        string title = ExtraxtTitle(text);
        if (title != string.Empty)
        {
            Console.WriteLine("Title: {0}", title);
        }
        string bodyText = ExtraxtBodyText(text);
        Console.WriteLine("Text: {0}", bodyText);
    }

    static string ExtraxtBodyText(string text)
    {
        int bodyStart = text.IndexOf(openingBodyTag) + openingBodyTag.Length;
        int bodyEnd = text.IndexOf(closingBodyTag);

        StringBuilder bodyText = new StringBuilder();
        bool insideTag = false;// Only add to text if checked chars are not inside a HTML tag.
        for (int i = bodyStart; i < bodyEnd; i++)
        {
            if (text[i] == '<')
            {
                insideTag = true;
            }
            if (text[i] == '>')
            {
                insideTag = false;
                bodyText.Append(" ");
            }
            if (!insideTag)
            {
                if (char.IsLetter(text[i]))
                {
                    bodyText.Append(text[i]);
                }
                else if (char.IsWhiteSpace(text[i]))
                {
                    bodyText.Append(text[i]);
                }
                else if (char.IsPunctuation(text[i]))
                {
                    bodyText.Append(text[i]);
                }
            }
        }

        return bodyText.ToString().Trim();
    }

    static string ExtraxtTitle(string text)
    {
        // No markup(<>/) is recognized inside a <title></title> tag by the web browsers,
        // so there is no need to check for tags containing inside a <title></title> tag.
        // Everything is percieved as text.

        StringBuilder title = new StringBuilder();

        int titleStart = text.IndexOf(openingTitleTag) + openingTitleTag.Length;
        int titleEnd = text.IndexOf(closingTitleTag);
        for (int i = titleStart; i < titleEnd; i++)
        {
            if (char.IsLetter(text[i]))
            {
                title.Append(text[i]);
            }
            else if (char.IsWhiteSpace(text[i]))
            {
                title.Append(text[i]);
            }
            else if (char.IsPunctuation(text[i]))
            {
                title.Append(text[i]);
            }
        }
        return title.ToString().Trim();
    }
}