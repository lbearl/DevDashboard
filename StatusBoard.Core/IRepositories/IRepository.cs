using System.Linq;

namespace StatusBoard.Core.IRepositories
{
    /// <summary>
    /// All functions common to all repositories
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        //Retrieve all elements
        IQueryable<TEntity> GetAll();

        //Pagination
        IQueryable<TEntity> PageAll(int skip, int take);
        
        //FindById
        TEntity FindById(object id);

        //The rest of CRUD (mostly CUD)
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

    }
}
