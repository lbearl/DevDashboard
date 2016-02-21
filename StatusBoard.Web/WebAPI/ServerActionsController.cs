using System.Web.Http;
using StatusBoard.Core.IServices;

namespace StatusBoard.Web.WebAPI
{
    public class ServerActionsController : ApiController
    {
        private readonly IPingService _pingService;
        public ServerActionsController(IPingService pingService)
        {
            _pingService = pingService;
        }
        [HttpGet]
        public IHttpActionResult TriggerNewServiceHistory(string hostname)
        {
            return _pingService.Ping(hostname) ? (IHttpActionResult) Ok() : NotFound();
        }
    }
}
