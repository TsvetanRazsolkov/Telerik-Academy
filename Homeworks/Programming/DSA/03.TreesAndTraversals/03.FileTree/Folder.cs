namespace _03.FileTree
{
    using System.Collections.Generic;
    using System.Linq;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; private set; }

        public ICollection<File> Files { get; private set; }

        public ICollection<Folder> ChildFolders { get; private set; }

        public void AddFolder(Folder folder)
        {
            // validation for null

            this.ChildFolders.Add(folder);
        }

        public void AddFiles(IEnumerable<File> files)
        {
            // validation for null

            foreach (var file in files)
            {
                this.Files.Add(file);
            }
        }

        public long GetSize()
        {
            long size = this.Files.Sum(fil => fil.Size) + this.ChildFolders.Sum(fol => fol.GetSize());

            return size;
        }
    }
}
