using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.Models;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Infrastructure.Repositories
{
    internal class ServerRepository : Repository<Server>, IServerRepository
    {

        public ServerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Server FindByHostname(string hostname)
        {
           return Set.FirstOrDefault(x => x.Hostname.Equals(hostname));
        }

        public Task<Server> FindByHostnameAsync(string hostname)
        {
            return Set.FirstOrDefaultAsync(x => x.Hostname.Equals(hostname));
        }

        public Task<Server> FindByHostnameAsync(CancellationToken cancellationToken, string hostname)
        {
            return Set.FirstOrDefaultAsync(x => x.Hostname.Equals(hostname), cancellationToken);
        }
    }
}
