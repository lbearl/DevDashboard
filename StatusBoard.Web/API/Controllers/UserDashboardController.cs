using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using StatusBoard.Core.IExternalServices;

namespace StatusBoard.Web.API.Controllers
{
    public class UserDashboardController : ApiController
    {
        private IJiraStatusService _jiraStatusService;

        public UserDashboardController(IJiraStatusService jiraStatusService)
        {
            _jiraStatusService = jiraStatusService;
        }
        /// <summary>
        /// A quick function to trigger gathering an extra history object for a given server, by hostname
        /// </summary>
        /// <param name="hostname">The hostname of the server to get the new service history record for</param>
        /// <returns></returns>
        [HttpGet] //in order to conform to REST, this needs to be a GET
        public JiraResponse GetJiraHighPriorityIssues()
        {
            return _jiraStatusService.JiraHighPriorityIssues();
        }
    }
}