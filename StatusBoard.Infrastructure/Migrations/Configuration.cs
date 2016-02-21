using StatusBoard.Core.Models;
using StatusBoard.Core.Models.Identity;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StatusBoard.Infrastructure.DbContext.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(StatusBoard.Infrastructure.DbContext.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Users.Add(new User() {EmailAddress = "lbearl@gmail.com", UserName = "lbearl"});
            context.Servers.Add(new Server() {Hostname = "https://www.thelagirl.com", IsActive = true});
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
