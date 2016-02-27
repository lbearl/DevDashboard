using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StatusBoard.Web.ViewModels
{
    /// <summary>
    /// Server Diagnostics objects used to display 
    /// </summary>
    public class ServerDiagnosticsVM
    {
        public string HostName { get; set; }
        public List<ServerHistory> ServerHistory { get; set; }
        public List<PingTimeSeries> TimeSeries { get; set; }
    }
    public class ServerHistory
    {
        public int ServerId { get; set; }
        public int PingStatus { get; set; }

        public int PingResponseTime { get; set; }
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
        public DateTime TakenAt { get; set; }
    }
}