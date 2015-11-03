namespace MusicSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    using Migrations;
    using Models;

    public class MusicSystemDbContext : DbContext
    {
        public MusicSystemDbContext()
            : base("MusicSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicSystemDbContext, Configuration>());
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }
    }
}
