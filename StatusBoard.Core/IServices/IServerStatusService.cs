using StatusBoard.Core.Models.Components.ServerStatus;

namespace StatusBoard.Core.IServices
{
    public interface IServerStatusService
    {
        PingStatus PingTest(string hostname);

        SSLCertificateStatus CheckSSLCertStatus(string hostname);

    }
}
