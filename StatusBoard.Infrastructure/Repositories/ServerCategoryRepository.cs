using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.Models;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Infrastructure.Repositories
{
    class ServerCategoryRepository : Repository<ServerCategory>, IServerCategoryRepository
    {
        public ServerCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
