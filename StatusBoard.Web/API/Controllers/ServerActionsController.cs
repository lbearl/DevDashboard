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
        /// <summary>
        /// A quick function to trigger gathering an extra history object for a given server, by hostname
        /// </summary>
        /// <param name="hostname">The hostname of the server to get the new service history record for</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult TriggerNewServiceHistory(string hostname)
        {
            return _pingService.Ping(hostname) ? (IHttpActionResult) Ok() : NotFound();
        }

        /// <summary>
        /// Gets all of the servers configured in the system
        /// </summary>
        /// <returns>A list of all of the servers</returns>
        [HttpGet] //in order to conform to REST, this should be a GET
        [Route(Constants.ApiController.Routes.Servers)]
        public List<ServerVM> GetServers()
        {
            return _serverService.GetAll().Select(server => new ServerVM()
            {
                ServerId = server.Id, DisplayName = server.DisplayName, HostName = server.Hostname
            }).ToList();
        }

        /// <summary>
        /// Gets all of the servers configured in the system
        /// </summary>
        /// <returns>A list of all of the servers</returns>
        [HttpGet] //in order to conform to REST, this should be a GET
        [Route(Constants.ApiController.Routes.Servers + "/{id}")]
        public ServerVM GetServers(int id)
        {
            var server = _serverService.FindById(id);
            return new ServerVM()
            {
                ServerId = server.Id,
                DisplayName = server.DisplayName,
                HostName = server.Hostname
            };
        }

        /// <summary>
        /// Gets a paginated list of all of the servers histories for a given server
        /// </summary>
        /// <param name="id">the ID of the server to get history from</param>
        /// <param name="start">The starting index of the histories</param>
        /// <param name="count">The number of histories to retrieve</param>
        /// <returns></returns>
        [HttpGet] //in order to conform to REST, this should be a GET
        [Route("api/ServerActions/{id}/GetServerHistoryForServer/{start}/{count}")]
        public ServerDiagnosticsVM GetServerHistoryForServer(int id, int start, int count)
        {
            var data = _serverHistoryService.GetPageOfHistoriesForHostById(id, start, count)
                .Select(history => new ServerHistory()
                {
                    PingResponseTime = history.PingResponseTime,
                    PingStatus = history.PingStatus,
                    ServerId = history.ServerId,
                    TakenAt = history.RecordedOn,
                    SslCertificateStatus = history.SslCertificateStatus,
                    SslCertificateExpiryDate = history.SslCertificateExpirationDate
                }).ToList();

            return new ServerDiagnosticsVM() { 
                HostName = _serverService.FindById(id).DisplayName,
                ServerHistory =  data.ToList(),
                TimeSeries = data.Select(history => new PingTimeSeries()
                {
                    PingResponseTime = history.PingResponseTime,
                    TakenAt = history.TakenAt
                }).ToList()};
        }
    }
}
