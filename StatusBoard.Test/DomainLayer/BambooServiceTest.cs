using Moq;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models.Components.DevStatus;
using Xunit;

namespace StatusBoard.Test.DomainLayer
{
    public class BambooServiceTest
    {
        private IBambooStatusService _bambooStatusService;

        //an example of MOQ's Linq to Moq functionality
        public BambooServiceTest()
        {
            _bambooStatusService = Mock.Of<IBambooStatusService>(l => l.CIStatus == new CIStatus
            {
                APBBuildNumber = "0",
                APBBuildStatus = true,
                CurrentBuildBuildStatus = false,
                CurrentBuildNumber = "1222",
                CurrentQCBuildNumber = "11222",
                CurrentQCBuildStatus = false
            });
        }

        [Fact]
        public void APBBuildStatusIsPopulatedAndBoolean()
        {
            Assert.IsType(typeof(bool), _bambooStatusService.CIStatus.APBBuildStatus);
            Assert.True(_bambooStatusService.CIStatus.APBBuildStatus);
        }
    }
}
