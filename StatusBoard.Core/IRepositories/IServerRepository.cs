using System.Threading;
using System.Threading.Tasks;
using StatusBoard.Core.Models;

namespace StatusBoard.Core.IRepositories
{
    public interface IServerRepository : IRepository<Server>
    {
        Server FindByHostname(string hostname);
        Task<Server> FindByHostnameAsync(string hostname);
        Task<Server> FindByHostnameAsync(CancellationToken cancellationToken, string hostname);
    }
}
