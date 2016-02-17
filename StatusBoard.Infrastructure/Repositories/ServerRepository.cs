using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.Models;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Infrastructure.Repositories
{
    public class ServerRepository : IServerRepository
    {
        readonly ServerContext _context = new ServerContext();
        public void Add(Server server)
        {
            _context.Servers.Add(server);
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
