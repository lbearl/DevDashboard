using StatusBoard.Core.Models.Components.ServerStatus;

namespace StatusBoard.Core.Models
{
    public class ServerStatus
    {
        public string ServerName { get; set; }
        
        public PingStatus PingStatus { get; set; }

        public SSLCertificateStatus CertificateStatus { get; set; }
    }
}
