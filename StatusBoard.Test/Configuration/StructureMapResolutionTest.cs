using StatusBoard.Core.IExternalServices;
using StatusBoard.Infrastructure;
using StatusBoard.Infrastructure.DependencyResolution;
using StructureMap;
using Xunit;

namespace StatusBoard.Test.Configuration
{
    public class StructureMapResolutionTest
    {
        //This test will just provide a high level validation that the DI container is
        //configured properly.
        [Fact]
        public void StructureMapConfigurationIsValid()
        {
            var container = new Container(x =>
            {
                x.IncludeRegistry<DefaultRegistry>();
            });

            container.AssertConfigurationIsValid();
            //validate that the IUnitOfWork resolves to the concerete UnitOfWork class
            Assert.IsType<UnitOfWork>(container.GetInstance<IUnitOfWork>());
        }
    }
}
