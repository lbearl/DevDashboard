using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using StatusBoard.Core;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.IServices;
using StatusBoard.Web.ViewModels;

namespace StatusBoard.Web.API.Controllers
{
    public class ServerActionsController : ApiController
    {
        private readonly IPingService _pingService;
        private readonly IServerService _serverService;
        private readonly IServerHistoryService _serverHistoryService;
        public ServerActionsController(IPingService pingService, IServerService serverService, IServerHistoryService serverHistory)
        {
            _pingService = pingService;
            _serverService = serverService;
            _serverHistoryService = serverHistory;
        }
        [HttpGet]
        public IHttpActionResult TriggerNewServiceHistory(string hostname)
        {
            return _pingService.Ping(hostname) ? (IHttpActionResult) Ok() : NotFound();
        }

        [HttpGet]
        [Route(Constants.ApiController.Routes.GetAllServers)]
        public List<ServerVM> GetAllServers()
        {
            return _serverService.GetAll().Select(server => new ServerVM()
            {
                ServerId = server.Id, DisplayName = server.DisplayName, HostName = server.Hostname, IsActive = server.IsActive
            }).ToList();
        }

        [HttpGet]
        public ServerDiagnosticsVM GetServerHistoryForServer(int? id)
        {
            if (id == null) return null;

            //retrieve all of the necessary data, and map it to the viewmodel
            //we are getting the first 250 data points right now, this should be made to be 
            //configurable in the future
            var data = _serverHistoryService.GetPageOfHistoriesForHostById(id.Value, 0, 250)
                .Select(history => new ServerHistory()
                {
                    PingResponseTime = history.PingResponseTime,
                    PingStatus = history.PingStatus,
                    ServerId = history.ServerId,
                    TakenAt = history.RecordedOn,
                    SslCertificateStatus = history.SslCertificateStatus.Equals("Valid"),
                    SslCertificateExpiryDate = history.SslCertificateExpirationDate
                });

            return new ServerDiagnosticsVM() { 
                HostName = _serverService.FindById(id.Value).DisplayName,
                ServerHistory =  data.ToList(),
                TimeSeries = data.Select(history => new PingTimeSeries()
                {
                    PingResponseTime = int.Parse(history.PingResponseTime),
                    TakenAt = history.TakenAt
                }).ToList()};
        }
    }
}
