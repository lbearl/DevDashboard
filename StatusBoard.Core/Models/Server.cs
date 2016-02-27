using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StatusBoard.Core.Models
{
    
    public class Server : BaseEntity
    {
        private ICollection<ServiceHistory> _serviceHistories;
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Hostname { get; set; }

        [MaxLength(200)]
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ServiceHistory> ServiceHistory
        {
            get { return _serviceHistories ?? (_serviceHistories = new List<ServiceHistory>()); }

            set { _serviceHistories = value; }
        }
    }
}
