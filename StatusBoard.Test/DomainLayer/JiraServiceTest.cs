using System.Collections.Generic;
using Moq;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models.Components.DevStatus;

namespace StatusBoard.Test.DomainLayer
{
    public class JiraServiceTest
    {
        private Mock<IJiraStatusService> jiraService;

        public JiraServiceTest() //test setup
        {
            jiraService = new Mock<IJiraStatusService>();
            jiraService.SetupGet(x => x.JiraStatuses).Returns(new List<JiraStatus>());
        }


    }
}
