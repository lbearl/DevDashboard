using System;
using System.Collections.Generic;

namespace StatusBoard.Web.API.ViewModels
{
    public class ServerDiagnostics
    {
        public string HostName { get; set; }
        public List<ServerHistory> ServerHistory { get; set; }
        public List<PingTimeSeries> TimeSeries { get; set; }
    }
    public class ServerHistory
    {
        public int ServerId { get; set; }
        public string PingStatus { get; set; }
        public string PingResponseTime { get; set; }
        public bool SslCertificateStatus { get; set; }

        public DateTime SslCertificateExpiryDate { get; set; }
        public DateTime TakenAt { get; internal set; }
    }

    public class PingTimeSeries
    {
        public int PingResponseTime { get; set; }
        /// <summary>
        /// This is the date time in milliseconds since Jan 1 1970 (JS is weird)
        /// </summary>
        public int TakenAt { get; set; }
    }
}