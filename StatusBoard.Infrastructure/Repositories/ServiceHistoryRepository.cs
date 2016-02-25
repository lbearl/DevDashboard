using System.Linq;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.Models;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Infrastructure.Repositories
{
    internal class ServiceHistoryRepository : Repository<ServiceHistory>, IServiceHistoryRepository
    {

        public ServiceHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


        public IQueryable<ServiceHistory> GetAllForHost(int id)
        {
            return Set.Where(x => x.ServerId == id).OrderBy(x=>x.RecordedOn);
        }
    }
}