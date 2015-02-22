using System;
using System.IO;

// Write a program that compares two text files line by line and prints the number of lines
// that are the same and the number of lines that are different.
// Assume the files have equal number of lines.

class CompareTextFiles
{
    const string firstFilePath = "..\\..\\FirstFile.txt";
    const string secondFilePath = "..\\..\\SecondFile.txt";

    static void Main()
    {
        StreamReader first = new StreamReader(firstFilePath);
        StreamReader second = new StreamReader(secondFilePath);

        int sameLinesCount = 0;
        int differentLinesCount = 0;

        using (first)
        using (second)
        {
            while (!first.EndOfStream || !second.EndOfStream)
            {

                if (first.ReadLine() == second.ReadLine())
                {
                    sameLinesCount++;
                }
                else
                {
                    differentLinesCount++;
                }
            }
        }
        Console.WriteLine("Number of same lines: {0}\nNumber of different lines: {1}",
                                                 sameLinesCount, differentLinesCount);
    }
}