using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;
using StatusBoard.Core.Models.Components.ServerStatus;

namespace StatusBoard.Infrastructure.Services
{
    public class HttpPingService : IPingService
    {
        private IUnitOfWork _unitOfWork;
        public HttpPingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Ping(string hostname)
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

            serviceHistory.SslCertificateStatus = serviceHistory.SslCertificateExpirationDate < DateTime.Now ? "Valid" : "Expired";
            _unitOfWork.ServiceHistoryRepository.Add(serviceHistory);
            _unitOfWork.SaveChanges();
        }
    }
}
