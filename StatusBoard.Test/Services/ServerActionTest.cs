using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Moq;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;
using StatusBoard.Web.API.Controllers;
using StatusBoard.Web.ViewModels;
using Xunit;
using Server = StatusBoard.Core.Models.Server;

namespace StatusBoard.Test.Services
{
    public class ServerActionTest
    {
        private Mock<IUnitOfWork> uow;
        private Mock<IPingService> pingService;

        public ServerActionTest()
        {
            uow = new Mock<IUnitOfWork>();
            
            pingService = new Mock<IPingService>();
            

        }

        [Fact]
        public void Assert_Trigger_New_Service_History_Returns_Ok_For_Valid_Host()
        {
            //Arrange
            var server = new Server() {Hostname = "testhost"};
            uow.Setup(x => x.ServerRepository.FindById(1)).Returns(server);
            pingService.Setup(x => x.Ping("testhost")).Returns(true);

            //Act
            var controller = new ServerActionsController(pingService.Object, uow.Object);
            var result = controller.TriggerNewServiceHistory("testhost");

            //Assert
            //we should get a 200 since we can ping the host
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Assert_Trigger_New_Service_History_Returns_NotFound_For_Invalid_Host()
        {
            //Arrange
            var server = new Server() { Hostname = "testhost" };
            uow.Setup(x => x.ServerRepository.FindById(1)).Returns(server);

            //Act
            var controller = new ServerActionsController(pingService.Object, uow.Object);
            var result = controller.TriggerNewServiceHistory("host that does not exist");

            //Assert
            //we throw a 404 if we couldn't ping the host
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Assert_Get_All_Servers_Returns_List()
        {
            //Arrange
            var servers = new List<Server>();
            for (var i = 0; i < 5; i++)
            {
                var name = "host" + i;
                servers.Add(new Server() {Hostname = name, DisplayName = name, IsActive = true, Id = i});
            }

            uow.Setup(x => x.ServerRepository.GetAll()).Returns(servers);

            //Act
            var controller = new ServerActionsController(pingService.Object, uow.Object);
            var result = controller.GetAllServers();

            //Assert
            //make sure the count of returned elements is correct
            Assert.Equal(result.Count, servers.Count);
            //make sure that we properly converted from domain to view model
            Assert.IsType<Web.ViewModels.Server>(result.First());
        }

        [Fact]
        public void Assert_Server_Diagnostic_For_Correct_Server_Is_Returned()
        {
            //Arrange
            var server = new Server() { Hostname = "testhost", Id = 2};
            uow.Setup(x => x.ServerRepository.FindById(2)).Returns(server);
            var serviceHistory = new List<ServiceHistory>();
            var serviceHistory2 = new List<ServiceHistory> {new ServiceHistory(){
                ServerId = 2,
                PingResponseTime = "20", //must be numeric value as it will be parsed (this probably shows that I made a bad decison in modeling the data)
                PingStatus = "", Id = 2,
                RecordedOn = DateTime.Now,
                SslCertificateExpirationDate = DateTime.Now,
                SslCertificateStatus = ""
            } };

            uow.Setup(x => x.ServiceHistoryRepository.GetAllForHost(1)).Returns(serviceHistory);
            uow.Setup(x => x.ServiceHistoryRepository.GetAllForHost(2)).Returns(serviceHistory2);

            //Act
            var controller = new ServerActionsController(pingService.Object, uow.Object);
            var result = controller.GetServerHistoryForServer(2);

            //Assert
            //make sure the view model type returned is correct
            Assert.IsType<ServerDiagnostics>(result);
            //validate that ServerHistory is a collection, and validate that the elements have correct data
            Assert.Collection(result.ServerHistory, x=> Assert.Equal(x.ServerId, 2));
        }

        [Fact]
        public void Assert_Server_Diagnostic_Fails_If_Diagnostic_Data_Missing()
        {
            //Arrange
            var serviceHistory = new List<ServiceHistory> { new ServiceHistory() { ServerId = 2 } };

            uow.Setup(x => x.ServiceHistoryRepository.GetAllForHost(2)).Returns(serviceHistory);

            //Act
            var controller = new ServerActionsController(pingService.Object, uow.Object);


            //Assert
            Assert.Throws<NullReferenceException>(() => controller.GetServerHistoryForServer(2));
        }

        [Fact]
        public void Assert_Server_Diagnostic_For_Null_Server_Is_Null()
        {
            //Arrange
            var serviceHistory = new List<ServiceHistory>();

            uow.Setup(x => x.ServiceHistoryRepository.GetAllForHost(1)).Returns(serviceHistory);

            //Act
            var controller = new ServerActionsController(pingService.Object, uow.Object);
            var result = controller.GetServerHistoryForServer(null);

            //Assert
            //make sure the count of returned elements is correct
            Assert.Null(result);
        }

    }
}
