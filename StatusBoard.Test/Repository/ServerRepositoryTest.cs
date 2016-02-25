using Moq;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.Models;
using Xunit;

namespace StatusBoard.Test.Repository
{
    public class ServerRepositoryTest
    {
        private Mock<IServerRepository> serverRepo;

        public ServerRepositoryTest()
        {
            serverRepo = new Mock<IServerRepository>();
        }

        [Fact]
        public void Assert_Repository_Returns_Appropriate_Server_By_Id()
        {
            //Arrange
            var server = new Server() {Id = 1, Hostname = "testhostname", DisplayName = "testdisplayname"};
            serverRepo.Setup(x => x.FindById(server.Id))
                .Returns(server);

            //Act
            var result = serverRepo.Object.FindById(1);

            //Assert
            serverRepo.Verify(x=>x.FindById(1), Times.Once());
            Assert.Equal(result.DisplayName, "testdisplayname");

        }

    }
}
