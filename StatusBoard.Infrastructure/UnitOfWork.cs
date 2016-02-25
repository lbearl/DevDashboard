using System.Threading.Tasks;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.IRepositories.Identity;
using StatusBoard.Infrastructure.DbContext;
using StatusBoard.Infrastructure.Repositories;
using StatusBoard.Infrastructure.Repositories.Identity;

namespace StatusBoard.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private IServerRepository _serverRepository;
        private IServiceHistoryRepository _serviceHistoryRepository;
        #endregion

        #region Constructors
        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new ApplicationDbContext(nameOrConnectionString);
        }
        #endregion

        #region IUnitOfWork Members

        public IRoleRepository RoleRepository => _roleRepository ?? (_roleRepository = new RoleRepository(_context));

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_context));

        public IServerRepository ServerRepository => _serverRepository ?? (_serverRepository = new ServerRepository(_context));

        public IServiceHistoryRepository ServiceHistoryRepository
            => _serviceHistoryRepository ?? (_serviceHistoryRepository = new ServiceHistoryRepository(_context));

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}
