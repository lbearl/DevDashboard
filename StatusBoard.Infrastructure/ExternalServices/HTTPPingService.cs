using System;
using System.Diagnostics;
using System.Net;
using StatusBoard.Core.Exceptions;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;

namespace StatusBoard.Infrastructure.ExternalServices
{
    public class HttpPingService : IPingService
    {
        private readonly IServerHistoryService _serverHistoryService;
        private readonly IServerService _serverService;
        public HttpPingService(IServerHistoryService serverHistoryService, IServerService serverService)
        {
            _serverHistoryService = serverHistoryService;
            _serverService = serverService;
        }

        /// <summary>
        /// Pings a host and records the SSL certificate status and whether the host is up
        /// </summary>
        /// <param name="hostname">Fully qualified host url (i.e. https://host.ext)</param>
        /// <returns>Success</returns>
        public bool Ping(string hostname)
        {
            try
            {
                var server = _serverService.FindServerByHostname(hostname);
                var serviceHistory = new ServiceHistory {Server = server};
                var request = WebRequest.Create(hostname);
                //so, this is a terrible hack and probably not truly representative of how long it actually takes to 
                //get a page... but its the best I can come up with right now.
                var watch = Stopwatch.StartNew();
                using (var response = request.GetResponse())
                {
                    serviceHistory.PingStatus = (int) ((HttpWebResponse) response).StatusCode;
                }
                watch.Stop();
                //this is a rough approximation of the time for the request
                serviceHistory.PingResponseTime = (int) watch.ElapsedMilliseconds;

                var cert = ((HttpWebRequest) request).ServicePoint.Certificate;
                if (cert == null) throw new CertificateException($"Certificate for {hostname} was null"); 
                serviceHistory.SslCertificateExpirationDate = DateTime.Parse(cert.GetExpirationDateString());

                serviceHistory.SslCertificateStatus = serviceHistory.SslCertificateExpirationDate > DateTime.Now;
                serviceHistory.RecordedOn = DateTime.UtcNow;
                _serverHistoryService.Add(serviceHistory);
            }
            catch (CertificateException)
            {
                return false;
            }
            return true;
        }
    }
}
