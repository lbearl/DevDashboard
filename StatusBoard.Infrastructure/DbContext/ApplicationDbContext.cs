﻿using System.Data.Entity;
using StatusBoard.Core.Models;
using StatusBoard.Core.Models.Identity;
using StatusBoard.Infrastructure.EFConfiguration;

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
    }
}
