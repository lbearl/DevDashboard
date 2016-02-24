using System;
using System.Diagnostics;
using System.Net;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;

namespace StatusBoard.Infrastructure.Services
{
    public class HttpPingService : IPingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HttpPingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                var server = _unitOfWork.ServerRepository.FindByHostname(hostname);
                var serviceHistory = new ServiceHistory {Server = server};
                var request = WebRequest.Create(hostname);
                var watch = Stopwatch.StartNew();
                using (var response = request.GetResponse())
                {
                    serviceHistory.PingStatus = ((HttpWebResponse)response).StatusCode.ToString();
                }
                watch.Stop();
                //this is a rough approximation of the time for the request
                serviceHistory.PingResponseTime = watch.ElapsedMilliseconds.ToString();

                var cert = ((HttpWebRequest) request).ServicePoint.Certificate;
                if (cert == null) throw new Exception("Certificate was null"); 
                serviceHistory.SslCertificateExpirationDate = DateTime.Parse(cert.GetExpirationDateString());

                serviceHistory.SslCertificateStatus = serviceHistory.SslCertificateExpirationDate > DateTime.Now ? "Valid" : "Expired";
                serviceHistory.RecordedOn = DateTime.Now;
                _unitOfWork.ServiceHistoryRepository.Add(serviceHistory);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
