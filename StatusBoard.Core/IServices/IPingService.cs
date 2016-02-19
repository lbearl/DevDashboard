using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusBoard.Core.Models.Components.ServerStatus;

namespace StatusBoard.Core.IServices
{
    public interface IPingService
    {
        PingStatus Ping(string hostname);
    }
}
