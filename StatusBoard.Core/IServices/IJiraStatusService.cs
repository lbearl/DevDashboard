using System.Collections.Generic;
using StatusBoard.Core.Models.Components.DevStatus;

namespace StatusBoard.Core.IServices
{
    public interface IJiraStatusService
    {
        List<JiraStatus> JiraStatuses { get; set; }
    }
}
