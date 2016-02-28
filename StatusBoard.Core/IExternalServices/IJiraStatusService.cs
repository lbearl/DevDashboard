using System.Collections.Generic;

namespace StatusBoard.Core.IExternalServices
{
    public interface IJiraStatusService
    {
        JiraResponse JiraHighPriorityIssues();
    }

    /// <summary>
    /// A representation of the JiraResponse object
    /// </summary>
    // OK, I'll admit, this is weird having this here... I probably should
    //move it to a more appropriate place, but I'm not sure where that would be
    public class JiraResponse
    {
        public string Expand { get; set; }
        public int StartAt { get; set; }
        public int MaxResults { get; set; }
        public int Total { get; set; }
        public List<Issue> Issues { get; set; }
        public class Issue
        {
            public string Expand { get; set; }
            public string Id { get; set; }
            public string Self { get; set; }
            public string Key { get; set; }
        }
    }
}
