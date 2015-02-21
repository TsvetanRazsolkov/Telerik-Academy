using System;
using System.Net;
using System.IO;

/* Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the 
current directory. Find in Google how to download files in C#. Be sure to catch all exceptions 
and to free any used resources in the finally block.  */

class DownloadFile
{
    static void Main()
    {
        WebClient downloader = new WebClient();

        string webURI = "http://westernschooloffengshui.com/wp-content/uploads/2015/01/sheep-redorbit.jpg";
        string fileName = "Picture.jpg";

        try
        {
            downloader.DownloadFile(webURI, fileName);
            Console.WriteLine("The file was downloaded at {0}", Directory.GetCurrentDirectory());
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine(nse.Message);
        }
        catch (WebException we)
        {
            Console.WriteLine(we.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
        catch (System.IO.IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Unknown error!");
        }
        finally
        {
            downloader.Dispose();
        }
    }
}