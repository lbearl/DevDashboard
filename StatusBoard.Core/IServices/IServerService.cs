using System.Collections.Generic;
using StatusBoard.Core.Models;

namespace StatusBoard.Core.IServices
{
    public interface IServerService : IService<Server, int>
    {
        Server FindServerByHostname(string hostname);

        List<Server> GetAll();
    }
}
