using StatusBoard.Core.IServices;

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
    }
}
