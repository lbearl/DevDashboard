using StatusBoard.Core.IExternalServices;

namespace StatusBoard.Infrastructure.ExternalServices
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
    }
}
