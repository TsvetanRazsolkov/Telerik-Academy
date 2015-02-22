using System;
using System.IO;

// Write a program that concatenates two text files into another text file.

class ConcatenateTextFiles
{
    const string firstInputPath = "..\\..\\TextFile1.txt";
    const string secondInputPath = "..\\..\\TextFile2.txt";
    const string outputPath = "..\\..\\ResultTextFile.txt";

    static void Main()
    {
        string firstFile;
        string secondFile;
        StreamReader reader = new StreamReader(firstInputPath);
        using (reader)
        {
            firstFile = reader.ReadToEnd();
        }
        reader = new StreamReader(secondInputPath);
        using (reader)
        {
            secondFile = reader.ReadToEnd();
        }
        StreamWriter writer = new StreamWriter(outputPath);
        using (writer)
        {
            writer.Write(firstFile);
            writer.Write(secondFile);
        }
        Console.WriteLine("Writing is done.");
    }
}