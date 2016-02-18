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
            throw new System.NotImplementedException();
        }

        public Task<List<Server>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Server>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public Task<Server> FindByIdAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Server> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Server server)
        {
            _context.Servers.Add(server);
            _context.SaveChanges();
        }

        public void Update(Server entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Server entity)
        {
            _context.Servers.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Server server)
        {
            _context.Entry(server).State = EntityState.Modified; 
        }

        public void Remove(int id)
        {
            var b = _context.Servers.Find(id);
            _context.Servers.Remove(b);
            _context.SaveChanges();
        }

        public IEnumerable<Server> GetServers()
        {
            return _context.Servers;
        }

        public Server FindById(int id)
        {
            return (from r in _context.Servers where r.Id == id select r).FirstOrDefault();
        }
    }
}
