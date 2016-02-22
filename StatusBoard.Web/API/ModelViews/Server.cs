using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatusBoard.Web.API.ModelViews
{
    public class Server
    {
        public int ServerId { get; set; }
        public string DisplayName { get; set; }
        public string HostName { get; set; }
        public bool IsActive { get; set; }
    }
}