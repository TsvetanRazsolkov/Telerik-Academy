using System;
using System.IO;
using System.Text;

// Modify the solution of the previous problem to replace only whole words (not strings).

class ReplaceWholeWords
{
    const string inputFilePath = "..\\..\\input.txt";
    const string outputFilePath = "..\\..\\output.txt";
    const string targetString = "start";
    const string replacementString = "finish";

    static void Main()
    {
        StreamReader reader = new StreamReader(inputFilePath);
        StreamWriter writer = new StreamWriter(outputFilePath);

        string inputLine = string.Empty;
        // Reading and writing line by line should work for very big files, unless there is only
        // one line in such a file(for 100MB it will not be a problem).
        using (reader)
        using (writer)
        {
            while (!reader.EndOfStream)
            {
                inputLine = reader.ReadLine();

                inputLine = ReplaceWords(inputLine);

                writer.WriteLine(inputLine);
            }
        }
    }

    static string ReplaceWords(string inputLine)
    {
        // It's awful sollution, but it works :)
        inputLine = inputLine.Replace(targetString + " ", replacementString + " ");
        inputLine = inputLine.Replace(targetString + ",", replacementString + ",");
        inputLine = inputLine.Replace(targetString + ".", replacementString + ".");
        inputLine = inputLine.Replace(targetString + "?", replacementString + "?");
        inputLine = inputLine.Replace(targetString + "!", replacementString + "!");
        inputLine = inputLine.Replace(targetString + "-", replacementString + "-");

        return inputLine;
    }   
}