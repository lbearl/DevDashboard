
using StatusBoard.Web.DependencyResolution;
using StructureMap;
using Xunit;

namespace StatusBoard.Test.WebUIAndDI
{
    public class StructureMapResolutionTest
    {
        [Fact]
        public void StructureMapConfigurationIsValid()
        {
            var container = new Container(x =>
            {
                x.IncludeRegistry<DefaultRegistry>();
            });

            container.AssertConfigurationIsValid();
        }
    }
}
