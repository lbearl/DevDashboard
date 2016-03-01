
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StatusBoard.Web.ViewModels
{
    public class ServerVM
    {
        public int ServerId { get; set; }
        [DisplayName("Display Name")]
        [MaxLength(200)]
        public string DisplayName { get; set; }
        [DisplayName("Host Name")]
        [MaxLength(200)]
        public string HostName { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}