using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Moq;
using StatusBoard.Core;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;
using StatusBoard.Web.Controllers;
using StatusBoard.Web.ViewModels;
using Xunit;

namespace StatusBoard.Test.Controllers
{
    public class ServersTest
    {
        private Mock<IServerService> _serverService;
        public ServersTest()
        {
            _serverService = new Mock<IServerService>();
        }

        [Fact]
        public void Assert_Index_Returns_Correct_View_With_list_Of_All_servers_as_ServerVMs()
        {
            //arrange
            //setup some test data to return
            var allServerList = new List<Server>() {
                new Server() {Id = 1, DisplayName = "Test 1"},
                new Server() {Id=2, DisplayName = "Test 2"}
            };
            _serverService.Setup(x => x.GetAll()).Returns(allServerList);
            var ctl = new ServersController(_serverService.Object);

            //act
            //we want to use "as" to cast here so that we can assert not null later. We could do an explicit
            //cast, but I feel this is more in the spirit of testing.
            var result = ((ViewResult) ctl.Index()).Model as IEnumerable<ServerVM>;

            //assert
            //first off we want to ensure that the result casted properly. If it didn't, then
            //the view isn't returning the expected value
            Assert.NotNull(result);
            //the Controller translates the domain entities into view models, so we need to ensure
            //we don't drop one somewhere
            Assert.Equal(result.Count(), 2);
            //ensure that the expected order is maintained
            Assert.Equal(result.First().ServerId, 1);
        }

        [Fact]
        public void Assert_Details_Page_Returns_Results_For_Only_The_Correct_Server()
        {
            //arrange
            //setup some test data to return
            var allServerList = new List<Server>() {
                new Server() {Id = 1, DisplayName = "Test 1"},
                new Server() {Id=2, DisplayName = "Test 2"}
            };
            _serverService.Setup(x => x.FindById(1)).Returns(allServerList.First());
            var ctl = new ServersController(_serverService.Object);

            //act
            //we want to use "as" to cast here so that we can assert not null later. We could do an explicit
            //cast, but I feel this is more in the spirit of testing.
            var result = ((ViewResult) ctl.Details(1)).Model as ServerVM;

            //assert
            //first off we want to ensure that result has the appropriate type
            Assert.NotNull(result);
            //next up we want to double check that the server returned is the server requested
            //this is also testing the VM translation happening in the controller
            Assert.Equal(result.ServerId, 1);

        }

        [Fact]
        public void Assert_Invalid_Server_Details_Returns_Not_Found()
        {
            //arrange
            var ctl = new ServersController(_serverService.Object);

            //act
            //we want to use "as" to cast here so that we can assert not null later. We could do an explicit
            //cast, but I feel this is more in the spirit of testing.
            var result = ctl.Details(99);

            //assert
            //since index 99 doesn't exist for the servers, we should throw a 404 result
            Assert.IsType<HttpNotFoundResult>(result);
        }

        [Fact]
        public void Assert_Null_Server_Details_Returns_Bad_Request()
        {
            //arrange
            var ctl = new ServersController(_serverService.Object);

            //act
            //we want to use "as" to cast here so that we can assert not null later. We could do an explicit
            //cast, but I feel this is more in the spirit of testing.
            var result = ctl.Details(null) as HttpStatusCodeResult;

            //assert
            //MVC does status codes weird, I can't compare on the HttpStatusCode enumeration, so we use a 400 literal here instead
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Assert_Create_Resolves_View_Model_to_Entity_And_Saves()
        {
            //arrange
            var servervm = new ServerVM() {ServerId = 1};
            var ctl = new ServersController(_serverService.Object);
            
            //act
            ctl.Create(servervm);

            //assert
            //make sure that the controller resolved the ServerVM into a Server and then saved it only once
            _serverService.Verify(x=>x.Add(It.IsAny<Server>()), Times.Once);
        }
    }
}
