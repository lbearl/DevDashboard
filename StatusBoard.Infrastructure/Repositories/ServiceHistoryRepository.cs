using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.Models;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Infrastructure.Repositories
{
    internal class ServiceHistoryRepository : Repository<ServiceHistory>, IServiceHistoryRepository
    {

        public ServiceHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


       
    }
}