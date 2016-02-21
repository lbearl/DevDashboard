using System;
using System.Data.Entity;
using System.Linq;
using StatusBoard.Core.Models;
using StatusBoard.Core.Models.Identity;
using StatusBoard.Infrastructure.EFConfiguration;
using System.Web;

namespace StatusBoard.Infrastructure.DbContext
{
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        //this is a bug! Need to come up with a way to inject the connection string for migrations
        public ApplicationDbContext() : base("default")
        {
        }

        internal ApplicationDbContext(string ctx) : base(ctx)
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Server> Servers { get; set; }
        public IDbSet<ServiceHistory> ServiceHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = HttpContext.Current != null && HttpContext.Current.User != null
                ? HttpContext.Current.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DateCreated = DateTime.Now;
                    ((BaseEntity)entity.Entity).UserCreated = currentUsername;
                }

                ((BaseEntity)entity.Entity).DateModified = DateTime.Now;
                ((BaseEntity)entity.Entity).UserModified = currentUsername;
            }

            return base.SaveChanges();
        }
    }
}
