using System;
using Microsoft.AspNet.Identity;

namespace StatusBoard.Core.Models.Identity
{
    public class ApplicationUser : IUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        public ApplicationUser(string userName)
            : this()
        {
            UserName = userName;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
    }
} 