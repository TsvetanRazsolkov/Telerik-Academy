using System;
using System.IO;

// Write a program that reads a text file and prints on the console its odd lines.

class OddLines
{
    const string pathInput = "..\\..\\sample.txt";
    static void Main()
    {
        StreamReader reader = new StreamReader(pathInput);
        using (reader)
        {
            int counter = 0;
            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();
                if (counter % 2 != 0)
                {
                    Console.WriteLine(currentLine);
                }
                counter++;
            }     
        }           
    }
}