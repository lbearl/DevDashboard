using System;
using System.Security.Cryptography.X509Certificates;
using StatusBoard.Core.Models;
using StatusBoard.Core.Models.Identity;

namespace StatusBoard.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StatusBoard.Infrastructure.DbContext.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(DbContext.ApplicationDbContext context)
        {

            context.Servers.AddOrUpdate(s => s.DisplayName, 
                new Server() {Id=1, Hostname = "https://www.thelagirl.com", IsActive = true, DateCreated = DateTime.UtcNow, UserCreated = "System", DisplayName = "The LA Girl"},
                new Server() { Id = 2, Hostname = "https://www.facebook.com", IsActive = true, DateCreated = DateTime.UtcNow, UserCreated = "System", DisplayName = "Facebook" }
                );

            context.Users.AddOrUpdate(u => u.UserId,
                new User() { UserId = new Guid("19874A8C-C807-4A8C-896E-D4DA879E9BAE"), EmailAddress = "lbearl@gmail.com", UserName = "lbearl", PasswordHash = "AK/+4XeffLAntk86ObaQ7uZCYvj+krzCmA02rS1QPH0OjA1ZhViUoHyG0E93ekJKug==", SecurityStamp = "6aef0310-b124-4102-bf98-bcd46f47d258" }
                );

            context.ServiceHistories.AddOrUpdate( sh => sh.Id,
                new ServiceHistory() {Id = 1, PingResponseTime = 44, PingStatus = 200, RecordedOn = DateTime.UtcNow, ServerId = 1, SslCertificateExpirationDate = DateTime.UtcNow + TimeSpan.FromDays(60), SslCertificateStatus = true},
                new ServiceHistory() { Id = 2, PingResponseTime = 44, PingStatus = 200, RecordedOn = DateTime.UtcNow, ServerId = 1, SslCertificateExpirationDate = DateTime.UtcNow + TimeSpan.FromDays(60), SslCertificateStatus = true }
                );
            //  This method will be called after migrating to the latest version.
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
