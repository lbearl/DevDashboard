using System.Collections.Generic;
using StatusBoard.Core.Models;

namespace StatusBoard.Core.IRepositories
{
    public interface IServerRepository : IRepository<Server>
    {
        void Add(Server server);
        void Edit(Server server);
        void Remove(int id);
        IEnumerable<Server> GetServers();
        Server FindById(int id);
    }
}
