using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Moq;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;
using StatusBoard.Web.API.Controllers;
using StatusBoard.Web.ViewModels;
using Xunit;
using StatusBoard.Core;

namespace StatusBoard.Test.Controllers
{
    public class ServerActionTest
    {
        private Mock<IServerService> serverServiceMock;

        private Mock<IServerHistoryService> serverHistoryMock;

        private Mock<IPingService> pingService;

        public ServerActionTest()
        {
            serverServiceMock = new Mock<IServerService>();
            serverHistoryMock = new Mock<IServerHistoryService>();
            pingService = new Mock<IPingService>();
            

        }

        [Fact]
        [Trait(Constants.Test.Trait.TraitType.Category, Constants.Test.Trait.TraitTypeValues.Controller)]
        public void Assert_Trigger_New_Service_History_Returns_Ok_For_Valid_Host()
        {
            //Arrange
            var server = new Server() {Hostname = "testhost"};
            serverServiceMock.Setup(x => x.FindById(1)).Returns(server);
            pingService.Setup(x => x.Ping("testhost")).Returns(true);

            //Act
            var controller = new ServerActionsController(pingService.Object, serverServiceMock.Object, serverHistoryMock.Object);
            var result = controller.TriggerNewServiceHistory("testhost");

            //Assert
            //we should get a 200 since we can ping the host
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        [Trait(Constants.Test.Trait.TraitType.Category, Constants.Test.Trait.TraitTypeValues.Controller)]
        public void Assert_Trigger_New_Service_History_Returns_NotFound_For_Invalid_Host()
        {
            //Arrange
            var server = new Server() { Hostname = "testhost" };
            serverServiceMock.Setup(x => x.FindById(1)).Returns(server);

            //Act
            var controller = new ServerActionsController(pingService.Object, serverServiceMock.Object, serverHistoryMock.Object);
            var result = controller.TriggerNewServiceHistory("host that does not exist");

            //Assert
            //we throw a 404 if we couldn't ping the host
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        [Trait(Constants.Test.Trait.TraitType.Category, Constants.Test.Trait.TraitTypeValues.Controller)]
        public void Assert_Get_All_Servers_Returns_List()
        {
            //Arrange
            var servers = new List<Server>();
            for (var i = 0; i < 5; i++)
            {
                var name = "host" + i;
                servers.Add(new Server() {Hostname = name, DisplayName = name, Id = i});
            }

            serverServiceMock.Setup(x => x.GetAll()).Returns(servers);

            //Act
            var controller = new ServerActionsController(pingService.Object, serverServiceMock.Object, serverHistoryMock.Object);
            var result = controller.GetServers();

            //Assert
            //make sure the count of returned elements is correct
            Assert.Equal(result.Count, servers.Count);
            //make sure that we properly converted from domain to view model
            Assert.IsType<ServerVM>(result.First());
        }


        [Fact]
        [Trait(Constants.Test.Trait.TraitType.Category, Constants.Test.Trait.TraitTypeValues.Controller)]
        public void Assert_Get_Servers_Gets_Correct_Server()
        {
            //Arrange
            var server = new Server() { Hostname = "test1", Id = 99 };
            serverServiceMock.Setup(x => x.FindById(99)).Returns(server);

            //Act
            var controller = new ServerActionsController(pingService.Object, serverServiceMock.Object, serverHistoryMock.Object);
            var result = controller.GetServers(server.Id);

            //Assert
            //make sure the id of the returned view model matches the original domain object server
            Assert.Equal(server.Id, result.ServerId);
            //make sure that we properly converted from domain to view model
            Assert.IsType<ServerVM>(result);
        }

        [Fact]
        [Trait(Constants.Test.Trait.TraitType.Category, Constants.Test.Trait.TraitTypeValues.Controller)]
        public void Assert_Server_Diagnostic_For_Correct_Server_Is_Returned()
        {
            //Arrange
            var server = new Server() { Hostname = "testhost", Id = 2};
            serverServiceMock.Setup(x => x.FindById(2)).Returns(server);
            var serviceHistory = new List<ServiceHistory>();
            var serviceHistory2 = new List<ServiceHistory> {new ServiceHistory(){
                ServerId = 2,
                PingResponseTime = 20,
                PingStatus = 200, Id = 2,
                RecordedOn = DateTime.Now,
                SslCertificateExpirationDate = DateTime.Now,
                SslCertificateStatus = true
            } };

            serverHistoryMock.Setup(x => x.GetPageOfHistoriesForHostById(1, 0, 250)).Returns(serviceHistory);
            serverHistoryMock.Setup(x => x.GetPageOfHistoriesForHostById(2, 0, 250)).Returns(serviceHistory2);

            //Act
            var controller = new ServerActionsController(pingService.Object, serverServiceMock.Object, serverHistoryMock.Object);
            var result = controller.GetServerHistoryForServer(2, 0, 250);

            //Assert
            //make sure the view model type returned is correct
            Assert.IsType<ServerDiagnosticsVM>(result);
            //validate that ServerHistory is a collection, and validate that the elements have correct data
            Assert.Collection(result.ServerHistory, x=> Assert.Equal(x.ServerId, 2));
        }

        [Fact]
        [Trait(Constants.Test.Trait.TraitType.Category, Constants.Test.Trait.TraitTypeValues.Controller)]
        public void Assert_Server_Diagnostic_Fails_If_Diagnostic_Data_Missing()
        {
            //Arrange
            var serviceHistory = new List<ServiceHistory> { new ServiceHistory() { ServerId = 2 } };

            serverHistoryMock.Setup(x => x.GetPageOfHistoriesForHostById(1, 0, 250)).Returns(serviceHistory);

            //Act
            var controller = new ServerActionsController(pingService.Object, serverServiceMock.Object, serverHistoryMock.Object);


            //Assert
            Assert.Throws<ArgumentNullException>(() => controller.GetServerHistoryForServer(2, 0, 250));
        }

    }
}
