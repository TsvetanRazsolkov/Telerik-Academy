namespace MusicSystem.Data
{
    using Models;
    using Repositories;

    public interface IMusicSystemData
    {
        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        IRepository<Song> Songs { get; }

        int SaveChanges();
    }
}
