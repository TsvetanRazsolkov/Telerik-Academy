using System;
using System.IO;

/* Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
reads its contents and prints it on the console.
Find in MSDN how to use System.IO.File.ReadAllText(…).
Be sure to catch all possible exceptions and print user-friendly error messages.  */

class ReadFileContents
{
    static void Main()
    {
        try
        {


            Console.Write("Enter full path to a text file: ");
            string path = Console.ReadLine();// C:\WINDOWS\win.ini
            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine(ptle.Message);
        }
        catch (System.IO.FileNotFoundException fne)
        {
            Console.WriteLine(fne.Message);
        }
        catch (System.IO.DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }
        catch (System.IO.DriveNotFoundException drnfe)
        {
            Console.WriteLine(drnfe.Message);
        }
        catch (System.IO.IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
        catch (OutOfMemoryException ome)
        {
            Console.WriteLine(ome.Message);
        }
        catch(Exception)
        {
            Console.WriteLine("Unknown error!");
        }
    }
}