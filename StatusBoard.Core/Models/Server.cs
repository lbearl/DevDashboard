using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StatusBoard.Core.Models
{
    
    public class Server : BaseEntity
    {
        private ICollection<ServiceHistory> _serviceHistories;
        private ICollection<ServerCategory> _serverCategory;
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Hostname { get; set; }

        [MaxLength(200)]
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ServerCategory>  ServerCategory
        {
            get {return _serverCategory ?? (_serverCategory = new List<ServerCategory>()); }
            set { _serverCategory = value; }
        }

        public virtual ICollection<ServiceHistory> ServiceHistory
        {
            get { return _serviceHistories ?? (_serviceHistories = new List<ServiceHistory>()); }

            set { _serviceHistories = value; }
        }
    }
}
