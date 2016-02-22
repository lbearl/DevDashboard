using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatusBoard.Web.API.ModelViews
{
    public class ServerHistory
    {
        public int ServerId { get; set; }
        public string PingStatus { get; set; }
        public string PingResponseTime { get; set; }
        public string SslCerficateStatus { get; set; }
        public DateTime SslCertificateExpiryDate { get; set; }
    }
}