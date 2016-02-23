namespace StatusBoard.Web.ViewModels
{
    public class Server
    {
        public int ServerId { get; set; }
        public string DisplayName { get; set; }
        public string HostName { get; set; }
        public bool IsActive { get; set; }
    }
}