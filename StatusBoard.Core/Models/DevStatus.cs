using System.Collections.Generic;
using StatusBoard.Core.Models.Components.DevStatus;

namespace StatusBoard.Core.Models
{
    public class DevStatus
    {
        public CIStatus CIStatus { get; set; }

        public List<JiraStatus> JiraStatuses { get; set; }


    }
}
