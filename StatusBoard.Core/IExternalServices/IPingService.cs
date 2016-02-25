namespace StatusBoard.Core.IExternalServices
{
    public interface IPingService
    {
        bool Ping(string hostname);
    }
}
