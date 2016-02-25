namespace StatusBoard.Core.IExternalServices
{
    public interface IServerStatusService
    {
        void PingTest(string hostname);

    }
}
