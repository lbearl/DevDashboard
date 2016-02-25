using System.Linq;
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
    }
}
