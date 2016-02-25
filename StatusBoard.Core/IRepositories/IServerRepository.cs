using StatusBoard.Core.Models;

namespace StatusBoard.Core.IRepositories
{
    public interface IServerRepository : IRepository<Server>
    {
        Server FindByHostname(string hostname);
    }
}
