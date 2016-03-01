namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditTracker : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Servers", "ServerCategory_Id", "dbo.ServerCategories");
            DropIndex("dbo.Servers", new[] { "ServerCategory_Id" });
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        AuditLogId = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        EventDateUTC = c.DateTime(nullable: false),
                        EventType = c.Int(nullable: false),
                        TypeFullName = c.String(nullable: false, maxLength: 512),
                        RecordId = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.AuditLogId);
            
            CreateTable(
                "dbo.AuditLogDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PropertyName = c.String(nullable: false, maxLength: 256),
                        OriginalValue = c.String(),
                        NewValue = c.String(),
                        AuditLogId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLogs", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);
            
            DropColumn("dbo.Servers", "ServerCategory_Id");
            DropTable("dbo.ServerCategories");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Servers", "ServerCategory_Id", c => c.Int());
            DropForeignKey("dbo.AuditLogDetails", "AuditLogId", "dbo.AuditLogs");
            DropIndex("dbo.AuditLogDetails", new[] { "AuditLogId" });
            DropTable("dbo.AuditLogDetails");
            DropTable("dbo.AuditLogs");
            CreateIndex("dbo.Servers", "ServerCategory_Id");
            AddForeignKey("dbo.Servers", "ServerCategory_Id", "dbo.ServerCategories", "Id");
        }
    }
}
