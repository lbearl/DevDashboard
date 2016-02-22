using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StatusBoard.Core.Models
{
    
    public class Server : BaseEntity
    {
        private ICollection<ServiceHistory> _serviceHistories;
        public int Id { get; set; }
        [DisplayName("Host Name"), Required]
        public string Hostname { get; set; }

        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        public string IpAddress { get; set; }

        public virtual ICollection<ServiceHistory> ServiceHistory
        {
            get { return _serviceHistories ?? (_serviceHistories = new List<ServiceHistory>()); }

            set { _serviceHistories = value; }
        }


    }
}
