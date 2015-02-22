using System;
using System.IO;

// Write a program that replaces all occurrences of the sub-string start with the sub-string 
// finish in a text file. Ensure it will work with large files (e.g. 100 MB).

class ReplaceSubstring
{
    const string inputFilePath = "..\\..\\input.txt";
    const string outputFilePath = "..\\..\\output.txt";
    const string targetSubstring = "start";
    const string replacementSubstring = "finish";

    static void Main()
    {
        StreamReader reader = new StreamReader(inputFilePath);
        StreamWriter writer = new StreamWriter(outputFilePath);

        string inputLine = string.Empty;
        // Reading and writing line by line should work for very big files, unless ther is only
        // one line in such a file(for 100MB it will not be a problem).
        using (reader)
        using (writer)        
        {
            while (!reader.EndOfStream)
            {
                inputLine = reader.ReadLine();
                inputLine = inputLine.Replace(targetSubstring, replacementSubstring);
                writer.WriteLine(inputLine);
            }
        }
    }    
}