using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.Models.Identity;

namespace StatusBoard.Infrastructure.ExternalServices
{
    public class UserStore : IUserRoleStore<ApplicationUser, Guid>, IUserPasswordStore<ApplicationUser, Guid>, IUserSecurityStampStore<ApplicationUser, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region IUserStore<ApplicationUser, Guid> Members
        public Task CreateAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var u = GetUser(user);

            _unitOfWork.UserRepository.Add(u);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var u = GetUser(user);

            _unitOfWork.UserRepository.Remove(u);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<ApplicationUser> FindByIdAsync(Guid userId)
        {
            var user = _unitOfWork.UserRepository.FindById(userId);
            return Task.FromResult<ApplicationUser>(GetIdentityUser(user));
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            var user = _unitOfWork.UserRepository.FindByUserName(userName);
            return Task.FromResult<ApplicationUser>(GetIdentityUser(user));
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentException("user");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("ApplicationUser does not correspond to a User entity.", nameof(user));

            PopulateUser(u, user);

            _unitOfWork.UserRepository.Update(u);
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {

        }
        #endregion

       

        #region IUserRoleStore<ApplicationUser, Guid> Members
        public Task AddToRoleAsync(ApplicationUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: roleName.");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("ApplicationUser does not correspond to a User entity.", nameof(user));
            var r = _unitOfWork.RoleRepository.FindByName(roleName);
            if (r == null)
                throw new ArgumentException("roleName does not correspond to a Role entity.", nameof(roleName));

            u.Roles.Add(r);
            _unitOfWork.UserRepository.Update(u);

            return _unitOfWork.SaveChangesAsync();
        }

        public Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("ApplicationUser does not correspond to a User entity.", nameof(user));

            return Task.FromResult<IList<string>>(u.Roles.Select(x => x.Name).ToList());
        }

        public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("ApplicationUser does not correspond to a User entity.", nameof(user));

            return Task.FromResult<bool>(u.Roles.Any(x => x.Name == roleName));
        }

        public Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("ApplicationUser does not correspond to a User entity.", nameof(user));

            var r = u.Roles.FirstOrDefault(x => x.Name == roleName);
            u.Roles.Remove(r);

            _unitOfWork.UserRepository.Update(u);
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region IUserPasswordStore<ApplicationUser, Guid> Members
        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.FromResult<bool>(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }
        #endregion

        #region IUserSecurityStampStore<ApplicationUser, Guid> Members
        public Task<string> GetSecurityStampAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            return Task.FromResult<string>(user.SecurityStamp);
        }

        public Task SetSecurityStampAsync(ApplicationUser user, string stamp)
        {
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }
        #endregion

        #region Private Methods
        private User GetUser(ApplicationUser applicationUser)
        {
            if (applicationUser == null)
                return null;

            var user = new User();
            PopulateUser(user, applicationUser);

            return user;
        }

        private void PopulateUser(User user, ApplicationUser applicationUser)
        {
            user.UserId = applicationUser.Id;
            user.UserName = applicationUser.UserName;
            user.PasswordHash = applicationUser.PasswordHash;
            user.SecurityStamp = applicationUser.SecurityStamp;
        }

        private ApplicationUser GetIdentityUser(User user)
        {
            if (user == null)
                return null;

            var identityUser = new ApplicationUser();
            PopulateIdentityUser(identityUser, user);

            return identityUser;
        }

        private void PopulateIdentityUser(ApplicationUser applicationUser, User user)
        {
            applicationUser.Id = user.UserId;
            applicationUser.UserName = user.UserName;
            applicationUser.PasswordHash = user.PasswordHash;
            applicationUser.SecurityStamp = user.SecurityStamp;
        }
        #endregion
    }
}