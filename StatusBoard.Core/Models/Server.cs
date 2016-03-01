using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StatusBoard.Core.Models
{
    
    public class Server : BaseEntity
    {
        private ICollection<ServiceHistory> _serviceHistories;
        /// <summary>
        /// The identifier of the server
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The hostname of the server as a URL
        /// </summary>
        [Required, MaxLength(200)]
        public string Hostname { get; set; }
        /// <summary>
        /// The human friendly display name
        /// </summary>
        [MaxLength(200)]
        public string DisplayName { get; set; }

        /// <summary>
        /// A collection of all server histories for the server
        /// </summary>
        public virtual ICollection<ServiceHistory> ServiceHistory
        {
            get { return _serviceHistories ?? (_serviceHistories = new List<ServiceHistory>()); }

            set { _serviceHistories = value; }
        }
    }
}
