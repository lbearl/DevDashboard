namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        EmailAddress = c.String(maxLength: 4000),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ServerCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryColor = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hostname = c.String(nullable: false, maxLength: 200),
                        DisplayName = c.String(maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        ServerCategoryId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServerCategories", t => t.ServerCategoryId, cascadeDelete: true)
                .Index(t => t.ServerCategoryId);
            
            CreateTable(
                "dbo.ServiceHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServerId = c.Int(nullable: false),
                        PingStatus = c.Int(nullable: false),
                        PingResponseTime = c.Int(nullable: false),
                        SslCertificateStatus = c.Boolean(nullable: false),
                        SslCertificateExpirationDate = c.DateTime(nullable: false),
                        RecordedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Servers", t => t.ServerId, cascadeDelete: true)
                .Index(t => t.ServerId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceHistories", "ServerId", "dbo.Servers");
            DropForeignKey("dbo.Servers", "ServerCategoryId", "dbo.ServerCategories");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.ServiceHistories", new[] { "ServerId" });
            DropIndex("dbo.Servers", new[] { "ServerCategoryId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.ServiceHistories");
            DropTable("dbo.Servers");
            DropTable("dbo.ServerCategories");
            DropTable("dbo.User");
            DropTable("dbo.Role");
        }
    }
}
