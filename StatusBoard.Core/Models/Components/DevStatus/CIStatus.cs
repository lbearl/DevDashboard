namespace StatusBoard.Core.Models.Components.DevStatus
{
    public class CIStatus
    {
        public string CurrentBuildNumber { get; set; }
        public bool CurrentBuildBuildStatus { get; set; }
        public string CurrentQCBuildNumber { get; set; }
        public bool CurrentQCBuildStatus { get; set; }
        public string APBBuildNumber { get; set; }
        public bool APBBuildStatus { get; set; }
    }
}
