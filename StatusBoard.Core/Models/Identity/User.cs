using System;
using System.Collections.Generic;

namespace StatusBoard.Core.Models.Identity
{
    public class User
    {
        #region Fields
        private ICollection<Role> _roles;
        #endregion

        #region Scalar Properties
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        //NOTE: want to make sure that this is actually secure
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        #endregion

        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            set { _roles = value; }
        } 
    }
}
