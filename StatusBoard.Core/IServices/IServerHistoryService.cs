using System.Collections.Generic;
using StatusBoard.Core.Models;

namespace StatusBoard.Core.IServices
{
    public interface IServerHistoryService : IService<ServiceHistory, int>
    {
        List<ServiceHistory> GetAllHistoriesForHostById(int id);

        List<ServiceHistory> GetPageOfHistoriesForHostById(int id, int start, int count);

    }
}
