using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;

namespace StatusBoard.Web.API.Controllers
{
    public class ServerActionsController : ApiController
    {
        private readonly IPingService _pingService;
        private readonly IUnitOfWork _unitOfWork;
        public ServerActionsController(IPingService pingService, IUnitOfWork unitOfWork)
        {
            _pingService = pingService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IHttpActionResult TriggerNewServiceHistory(string hostname)
        {
            return _pingService.Ping(hostname) ? (IHttpActionResult) Ok() : NotFound();
        }

        [HttpGet]
        public List<ModelViews.Server> GetAllServers()
        {
            return _unitOfWork.ServerRepository.GetAll().ToList().Select(server => new ModelViews.Server()
            {
                ServerId = server.Id, DisplayName = server.DisplayName, HostName = server.Hostname, IsActive = server.IsActive
            }).ToList();
        }


        public List<ModelViews.ServerHistory> GetServerHistoryForServer(int id)
        {
            return
                _unitOfWork.ServiceHistoryRepository.GetAllForHost(id)
                    .ToList()
                    .Select(history => new ModelViews.ServerHistory()
                    {
                        PingResponseTime = history.PingResponseTime,
                        PingStatus = history.PingStatus,
                        ServerId = history.ServerId,
                        SslCerficateStatus = history.SslCertificateStatus,
                        SslCertificateExpiryDate = history.SslCertificateExpirationDate
                    }).ToList();
        }
    }
}
