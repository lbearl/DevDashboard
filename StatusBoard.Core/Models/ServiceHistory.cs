using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace StatusBoard.Core.Models
{
    public class ServiceHistory
    {

        public int Id { get; set; }
        public int ServerId { get; set; }
        public string PingStatus { get; set; }
        public string PingResponseTime { get; set; }
        public string SslCertificateStatus { get; set; }
        public DateTime SslCertificateExpirationDate { get; set; }

        /// <summary>
        /// The date time when the service history record was recorded
        /// </summary>
        public DateTime RecordedOn { get; set; }

        public virtual Server Server { get; set; }
    }
}
