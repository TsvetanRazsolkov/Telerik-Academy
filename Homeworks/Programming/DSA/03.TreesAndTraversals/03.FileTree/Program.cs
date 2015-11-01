/*Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders }
 and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS.
 Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly.
 Use recursive DFS traversal.*/
namespace _03.FileTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            // Using the Help folder - it is quicker and there are no access restrictions
            string rootFolderName = "C:\\Windows\\Help";

            var rootFolder = new Folder(rootFolderName);

            FillFolder(new DirectoryInfo(rootFolderName), rootFolder);

            PrintFolders(rootFolder);
        }

        private static void PrintFolders(Folder folder, int offset = 0)
        {
            Console.WriteLine("{0}Folder -> {1}; Size -> {2} bytes.", new string('-', offset), folder.Name, folder.GetSize());
            foreach (var file in folder.Files)
            {
                Console.WriteLine(new string('-', offset + 2) + file.Name);
            }

            foreach (var subFolder in folder.ChildFolders)
            {
                PrintFolders(subFolder, offset + 2);
            }
        }

        private static void FillFolder(DirectoryInfo directory, Folder rootFolder)
        {
            var files = directory.GetFiles()
                                 .Select(fInfo => new File(fInfo.Name, (int)fInfo.Length));

            rootFolder.AddFiles(files);

            foreach (var dir in directory.GetDirectories())
            {
                var folder = new Folder(dir.Name);
                rootFolder.AddFolder(folder);
                FillFolder(dir, folder);
            }
        }
    }
}
