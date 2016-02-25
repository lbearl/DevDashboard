using System;

namespace StatusBoard.Core.IServices
{
    /// <summary>
    /// This interface defines basic CRUD operations that are common across all services
    /// </summary>
    /// <typeparam name="TEntity">The domain type of the service</typeparam>
    /// <typeparam name="TPK">The Type to use for the key</typeparam>
    public interface IService<TEntity, TPK> : IDisposable where TEntity : class
    {
        TEntity FindById(TPK id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
