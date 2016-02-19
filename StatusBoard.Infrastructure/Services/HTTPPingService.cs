using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models.Components.ServerStatus;

namespace StatusBoard.Infrastructure.Services
{
    public class HttpPingService : IPingService
    {
        public PingStatus Ping(string hostname)
        {
            return new PingStatus
            {
                IsUp = true,
                PingTime = 200,
                ServerName = hostname,
                ServiceStatus = Core.Models.Components.ServiceStatus.Good
            };
        }
    }
}
