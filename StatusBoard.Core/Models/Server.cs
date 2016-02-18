using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StatusBoard.Core.Models
{
    public class Server
    {
        public int Id { get; set; }
        [DisplayName("Host Name"), Required]
        public string Hostname { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        public string IpAddress { get; set; }
    }
}
