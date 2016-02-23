using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;
using StatusBoard.Web.ViewModels;
using Server = StatusBoard.Web.ViewModels.Server;

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
        [Route("api/ServerActions/GetAllServers")]
        public List<Server> GetAllServers()
        {
            return _unitOfWork.ServerRepository.GetAll().ToList().Select(server => new Server()
            {
                ServerId = server.Id, DisplayName = server.DisplayName, HostName = server.Hostname, IsActive = server.IsActive
            }).ToList();
        }

        [HttpGet]
        public ServerDiagnostics GetServerHistoryForServer(int? id)
        {
            if (id == null) return null;

            //retrieve all of the necessary data, and map it to the viewmodel
            var data = _unitOfWork.ServiceHistoryRepository.GetAllForHost(id.Value)
                .Select(history => new ServerHistory()
                {
                    PingResponseTime = history.PingResponseTime,
                    PingStatus = history.PingStatus,
                    ServerId = history.ServerId,
                    TakenAt = history.RecordedOn,
                    SslCertificateStatus = history.SslCertificateStatus.Equals("Valid"),
                    SslCertificateExpiryDate = history.SslCertificateExpirationDate
                }).ToList();

            return new ServerDiagnostics() { 
                HostName = _unitOfWork.ServerRepository.FindById(id.Value).DisplayName,
                ServerHistory =  data,
                TimeSeries = data.Select(history => new PingTimeSeries()
                {
                    PingResponseTime = int.Parse(history.PingResponseTime),
                    TakenAt = history.TakenAt
                }).ToList()};
        }
    }
}
