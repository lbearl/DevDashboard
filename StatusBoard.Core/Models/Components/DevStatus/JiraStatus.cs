namespace StatusBoard.Core.Models.Components.DevStatus
{
    public class JiraStatus
    {
        public string JiraKey { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Priority { get; set; }
        public string Assignee { get; set; }
        public string AssigneeUrl { get; set; }

    }
}
