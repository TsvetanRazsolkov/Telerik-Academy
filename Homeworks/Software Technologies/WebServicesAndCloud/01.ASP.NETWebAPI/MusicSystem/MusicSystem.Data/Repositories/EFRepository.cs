namespace MusicSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class EFRepository<T> : IRepository<T> where T : class
    {
        private DbContext context; // can be an interface for testing purposes.
        private IDbSet<T> set;

        public EFRepository() :
            this(new MusicSystemDbContext())
        {
        }

        public EFRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeEntityState(T entity, EntityState entityState)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = entityState;
        }
    }
}
