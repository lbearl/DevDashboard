using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.Models.Identity;

namespace StatusBoard.Infrastructure.ExternalServices
{
    public class RoleStore : IQueryableRoleStore<IdentityRole, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;

        public RoleStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region IRoleStore<IdentityRole, Guid> Members
        public Task CreateAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            var r = getRole(role);

            _unitOfWork.RoleRepository.Add(r);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            var r = getRole(role);

            _unitOfWork.RoleRepository.Remove(r);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<IdentityRole> FindByIdAsync(Guid roleId)
        {
            var role = _unitOfWork.RoleRepository.FindById(roleId);
            return Task.FromResult<IdentityRole>(getIdentityRole(role));
        }

        public Task<IdentityRole> FindByNameAsync(string roleName)
        {
            var role = _unitOfWork.RoleRepository.FindByName(roleName);
            return Task.FromResult<IdentityRole>(getIdentityRole(role));
        }

        public Task UpdateAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            var r = getRole(role);
            _unitOfWork.RoleRepository.Update(r);
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            // Dispose does nothing since we want Unity to manage the lifecycle of our Unit of Work
        }
        #endregion

        #region IQueryableRoleStore<IdentityRole, Guid> Members
        public IQueryable<IdentityRole> Roles
        {
            get
            {
                return _unitOfWork.RoleRepository
                    .GetAll()
                    .Select(x => getIdentityRole(x))
                    .AsQueryable();
            }
        }
        #endregion

        #region Private Methods
        private Role getRole(IdentityRole identityRole)
        {
            if (identityRole == null)
                return null;
            return new Role
            {
                RoleId = identityRole.Id,
                Name = identityRole.Name
            };
        }

        private IdentityRole getIdentityRole(Role role)
        {
            if (role == null)
                return null;
            return new IdentityRole
            {
                Id = role.RoleId,
                Name = role.Name
            };
        }
        #endregion
    }
}