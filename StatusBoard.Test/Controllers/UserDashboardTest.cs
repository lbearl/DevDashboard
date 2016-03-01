using Moq;
using StatusBoard.Core;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Web.API.Controllers;
using Xunit;


namespace StatusBoard.Test.Controllers
{
    [Trait(Constants.Test.Trait.TraitType.Category, Constants.Test.Trait.TraitTypeValues.Controller)]
    public class UserDashboardTest
    {
        private Mock<IJiraStatusService> _statusService;

        public UserDashboardTest()
        {
            _statusService = new Mock<IJiraStatusService>();
        }

        [Fact]
        public void Assert_JiraResponse_Object_Is_Returned()
        {
            
            //Arrange
            var response = new JiraResponse() { Total=90 };
            _statusService.Setup(x => x.JiraHighPriorityIssues()).Returns(response);

            //Act
            var controller = new UserDashboardController(_statusService.Object);
            var result = controller.GetJiraHighPriorityIssues();

            //Assert
            //make sure the id of the returned view model matches the original domain object server
            Assert.Equal(response.Total, result.Total);
            //make sure that the JiraResponse type is returned
            //this type is a little odd in that it isn't really a domain object or a view model,
            //instead it is just an object I am proxying because JIRA doesn't send a proper CORS 
            //header (and even if it did, I don't have access to JIRA to whitelist my new application)
            Assert.IsType<JiraResponse>(result);
            

        }

    }
}
