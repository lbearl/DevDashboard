﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StatusBoard.Core.Models
{
    
    public class Server : BaseEntity
    {
        private ICollection<ServiceHistory> _serviceHistories;
        private ICollection<ServerCategory> _serverCategory;
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
        /// A flag to determine if the server is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// For foreign key on the server category
        /// </summary>
        public int ServerCategoryId { get; set; }

        /// <summary>
        /// A reference to the server category associated with the server
        /// </summary>
        public virtual ServerCategory ServerCategory {get; set; }
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
