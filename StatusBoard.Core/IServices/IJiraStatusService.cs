using System.Collections.Generic;
using StatusBoard.Core.Models.Components.DevStatus;

namespace StatusBoard.Core.IServices
{
    public interface IJiraStatusService
    {
        void JiraHighPriorityIssues();
    }
}
