using System;

namespace StatusBoard.Core.Models.Components.ServerStatus
{
    public class SSLCertificateStatus
    {
        public string ServerName { get; set; }
        public DateTime Expiration { get; set; }
        public bool Expired { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }
}
