using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StatusBoard.Web.ViewModels
{
    public class Server
    {
        public int ServerId { get; set; }
        [DisplayName("Display Name")]
        [MaxLength(20)]
        public string DisplayName { get; set; }
        [DisplayName("Host Name")]
        [MaxLength(20)]
        public string HostName { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}