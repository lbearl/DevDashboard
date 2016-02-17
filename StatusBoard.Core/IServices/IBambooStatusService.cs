using StatusBoard.Core.Models.Components.DevStatus;

namespace StatusBoard.Core.IServices
{
    public interface IBambooStatusService
    {
        CIStatus CIStatus { get; set; }

    }
}
