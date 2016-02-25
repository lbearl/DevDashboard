using System.Data.Entity;
using System.Linq;
using StatusBoard.Core.IRepositories;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Infrastructure.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _context;
        private DbSet<TEntity> _set;

        internal Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> Set => _set ?? (_set = _context.Set<TEntity>());

        public IQueryable<TEntity> GetAll()
        {
            return Set;
        }
        

        public IQueryable<TEntity> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take);
        }
        

        public TEntity FindById(object id)
        {
            return Set.Find(id);
        }


        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            //this will handle the common case of reattaching detached objects
            //note that on key conflict it will explode nicely
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }
    }
}
