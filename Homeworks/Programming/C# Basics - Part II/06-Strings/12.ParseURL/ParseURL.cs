using System;

/* Write a program that parses an URL address given in the format: [protocol]://[server]/
[resource] and extracts from it the [protocol], [server] and [resource] elements.
Example:
URL	                                                  Information
http://telerikacademy.com/Courses/Courses/Details/212 [protocol] = http 
                                                      [server] = telerikacademy.com 
                                                      [resource] = /Courses/Courses/Details/212 
*/
    class ParseURL
    {
        const string ProtocolSeparator = "://";
        const string ResourceSeparator = "/";

        static void Main()
        {
            // Console.Write("Enter URL address: ");
            // string address = Console.ReadLine();
            string address = "http://telerikacademy.com/Courses/Courses/Details/212";

            int indexOfServer = address.IndexOf(ProtocolSeparator) + ProtocolSeparator.Length;
            int indexOfResource = address.IndexOf(ResourceSeparator, indexOfServer);

            string protocol = address.Substring(0, indexOfServer - ProtocolSeparator.Length);
            string server = address.Substring(indexOfServer, indexOfResource - indexOfServer);
            string resource = address.Substring(indexOfResource, address.Length - indexOfResource);

            Console.WriteLine(@"[protocol] = {0}
[server] = {1}
[resource] = {2}", protocol, server, resource);
        }
    }