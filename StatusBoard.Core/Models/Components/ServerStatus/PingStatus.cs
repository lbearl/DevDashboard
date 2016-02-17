namespace StatusBoard.Core.Models.Components.ServerStatus
{
    public class PingStatus
    {
        public string ServerName { get; set; }
        public bool IsUp { get; set; }
        public float PingTime { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }

}
