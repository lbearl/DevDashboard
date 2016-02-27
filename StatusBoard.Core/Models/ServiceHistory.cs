using System;
using System.ComponentModel.DataAnnotations;

namespace StatusBoard.Core.Models
{
    public class ServiceHistory
    {
        /// <summary>
        /// The Id of this history object
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Server that this history object corresponds to
        /// </summary>
        public int ServerId { get; set; }
        /// <summary>
        /// The HTTP status code of the request
        /// </summary>
        public int PingStatus { get; set; }
        /// <summary>
        /// The time in ms that it took to GET the page
        /// </summary>
        public int PingResponseTime { get; set; }
        /// <summary>
        /// True if ssl certificate is valid, false otherwise
        /// </summary>
        public bool SslCertificateStatus { get; set; }
        /// <summary>
        /// The date time when the SSL certificate will expire
        /// </summary>
        public DateTime SslCertificateExpirationDate { get; set; }

        /// <summary>
        /// The date time when the service history record was recorded
        /// </summary>
        public DateTime RecordedOn { get; set; }

        /// <summary>
        /// A lazy loaded reference to the server that this history is for
        /// </summary>
        public virtual Server Server { get; set; }
    }
}
