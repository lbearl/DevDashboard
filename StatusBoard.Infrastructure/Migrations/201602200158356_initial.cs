namespace StatusBoard.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                "dbo.Servers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hostname = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServerId = c.Int(nullable: false),
                        PingStatus = c.String(),
                        PingResponseTime = c.String(),
                        SslCertificateStatus = c.String(),
                        SslCertificateExpirationDate = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.ServiceHistories", new[] { "ServerId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.ServiceHistories");
            DropTable("dbo.Servers");
            DropTable("dbo.User");
            DropTable("dbo.Role");
        }
    }
}
