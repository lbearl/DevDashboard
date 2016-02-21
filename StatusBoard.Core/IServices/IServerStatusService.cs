namespace StatusBoard.Core.IServices
{
    public interface IServerStatusService
    {
        void PingTest(string hostname);

        void CheckSSLCertStatus(string hostname);

    }
}
