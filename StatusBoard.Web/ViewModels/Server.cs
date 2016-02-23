using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatusBoard.Web.ViewModels
{
    public class Server
    {
        public string Hostname { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
    }
}