using System.Threading;
using System.Threading.Tasks;
using StatusBoard.Core.Models.Identity;

namespace StatusBoard.Core.IRepositories.Identity
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
