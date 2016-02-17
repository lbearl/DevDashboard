using System.Data.Entity;
using StatusBoard.Core.Models;

namespace StatusBoard.Infrastructure.DbContext
{
    public class ServerContext : System.Data.Entity.DbContext
    {
        public ServerContext() : base("default")
        {
        }

        public DbSet<Server> Servers { get; set; }

    }
}
