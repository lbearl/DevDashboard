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
        public PingStatus PingTest(string hostname)
        {
            return _pingService.Ping(hostname);
        }

        public SSLCertificateStatus CheckSSLCertStatus(string hostname)
        {
            return null;
        }
    }
}
