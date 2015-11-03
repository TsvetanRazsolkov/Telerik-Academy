namespace MusicSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Models;
    using Repositories;

    public class MusicSystemData : IMusicSystemData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public MusicSystemData()
            : this(new MusicSystemDbContext())
        {
        }

        public MusicSystemData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Artist> Artists
        {
            get { return this.GetRepository<Artist>(); }
        }

        public IRepository<Album> Albums
        {
            get { return this.GetRepository<Album>(); }
        }

        public IRepository<Song> Songs
        {
            get { return this.GetRepository<Song>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(EFRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
