using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models.Components.ServerStatus;

namespace StatusBoard.Infrastructure.Services
{
    public class ServerStatusService : IServerStatusService
    {
        private IPingService _pingService;

        public ServerStatusService(IPingService pingService)
        {
            _pingService = pingService;
        }
        public void PingTest(string hostname)
        {
            _pingService.Ping(hostname);
        }

        public void CheckSSLCertStatus(string hostname)
        {
            return;
        }
    }
}
