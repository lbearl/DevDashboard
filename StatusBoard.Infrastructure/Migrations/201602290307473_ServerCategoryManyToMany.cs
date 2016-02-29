namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServerCategoryManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServerCategories", "Server_Id", "dbo.Servers");
            DropIndex("dbo.ServerCategories", new[] { "Server_Id" });
            CreateTable(
                "dbo.ServerCategoryServers",
                c => new
                    {
                        ServerCategory_Id = c.Int(nullable: false),
                        Server_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServerCategory_Id, t.Server_Id })
                .ForeignKey("dbo.ServerCategories", t => t.ServerCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Servers", t => t.Server_Id, cascadeDelete: true)
                .Index(t => t.ServerCategory_Id)
                .Index(t => t.Server_Id);
            
            AddColumn("dbo.ServerCategories", "DateCreated", c => c.DateTime());
            AddColumn("dbo.ServerCategories", "UserCreated", c => c.String());
            AddColumn("dbo.ServerCategories", "DateModified", c => c.DateTime());
            AddColumn("dbo.ServerCategories", "UserModified", c => c.String());
            DropColumn("dbo.ServerCategories", "Server_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServerCategories", "Server_Id", c => c.Int());
            DropForeignKey("dbo.ServerCategoryServers", "Server_Id", "dbo.Servers");
            DropForeignKey("dbo.ServerCategoryServers", "ServerCategory_Id", "dbo.ServerCategories");
            DropIndex("dbo.ServerCategoryServers", new[] { "Server_Id" });
            DropIndex("dbo.ServerCategoryServers", new[] { "ServerCategory_Id" });
            DropColumn("dbo.ServerCategories", "UserModified");
            DropColumn("dbo.ServerCategories", "DateModified");
            DropColumn("dbo.ServerCategories", "UserCreated");
            DropColumn("dbo.ServerCategories", "DateCreated");
            DropTable("dbo.ServerCategoryServers");
            CreateIndex("dbo.ServerCategories", "Server_Id");
            AddForeignKey("dbo.ServerCategories", "Server_Id", "dbo.Servers", "Id");
        }
    }
}
