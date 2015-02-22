using System;
using System.IO;

// Write a program that deletes from given text file all odd lines.
// The result should be in the same file.

class DeleteOddLines
{
    const string filePath = "..\\..\\sampletext.txt";

    static void Main()
    {
        // Check sampletext.txt file before running.

        string[] allLines = File.ReadAllLines(filePath);

        string[] evenLines = new string[allLines.Length/2];

        for (int i = 0; i < allLines.Length; i++)
        {
            if (i % 2 == 0)
            {
                evenLines[i/2] = allLines[i];
            }
        }
        File.WriteAllLines(filePath, evenLines);        
    }
}