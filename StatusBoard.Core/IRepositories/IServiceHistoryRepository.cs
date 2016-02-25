using System.Linq;
using StatusBoard.Core.Models;

namespace StatusBoard.Core.IRepositories
{
    public interface IServiceHistoryRepository : IRepository<ServiceHistory>
    {
        IQueryable<ServiceHistory> GetAllForHost(int id);
    }
}