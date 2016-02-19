using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.Models;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Infrastructure.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly ApplicationDbContext _context;

        public ServerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public List<Server> GetAll()
        {
            return _context.Servers.ToList();
        }

        public Task<List<Server>> GetAllAsync()
        {
            return _context.Servers.ToListAsync();
        }

        public Task<List<Server>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _context.Servers.ToListAsync(cancellationToken);
        }

        public List<Server> PageAll(int skip, int take)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Server>> PageAllAsync(int skip, int take)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Server>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            throw new System.NotImplementedException();
        }

        public Server FindById(object id)
        {
            return _context.Servers.Where(x => x.Id == (int) id).FirstOrDefault();
        }

        public Task<Server> FindByIdAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Server> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Server entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Server entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Server entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
