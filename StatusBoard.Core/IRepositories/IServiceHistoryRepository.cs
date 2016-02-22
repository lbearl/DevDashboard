using System.Collections.Generic;
using StatusBoard.Core.Models;

namespace StatusBoard.Core.IRepositories
{
    public interface IServiceHistoryRepository : IRepository<ServiceHistory>
    {
        List<ServiceHistory> GetAllForHost(int id);
    }
}