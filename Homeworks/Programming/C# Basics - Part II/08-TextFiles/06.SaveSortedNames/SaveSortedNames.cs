using System;
using System.IO;
using System.Collections.Generic;

/* Write a program that reads a text file containing a list of strings, sorts them and saves them
to another text file.
Example:
input.txt	output.txt
Ivan        George
Peter       Ivan 
Maria       Maria
George	    Peter       */

class SaveSortedNames
{
    const string inputFilePath = "..\\..\\input.txt";
    const string outputFilePath = "..\\..\\output.txt";

    static void Main()
    {
        StreamReader reader = new StreamReader(inputFilePath);

        List<string> inputStrings = new List<string>();

        using (reader)
        {
            while (!reader.EndOfStream)
            {
                inputStrings.Add(reader.ReadLine().Trim());
            }
        }

        inputStrings.Sort();

        StreamWriter writer = new StreamWriter(outputFilePath);

        using (writer)
        {
            foreach (var word in inputStrings)
            {
                writer.WriteLine(word);
            }
        }
    }
}