﻿using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StatusBoard.Core.IRepositories.Identity;
using StatusBoard.Core.Models.Identity;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Infrastructure.Repositories.Identity
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }

        public User FindByEmail(string email)
        {
            return Set.FirstOrDefault(x => x.EmailAddress == email);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return Set.FirstOrDefaultAsync(x => x.EmailAddress == email);
        }

        public Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email)
        {
            return Set.FirstOrDefaultAsync(x => x.EmailAddress == email, cancellationToken);
        }
    }
}
