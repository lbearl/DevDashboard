namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServerServerCategoryOneToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServerServerCategories", "Server_Id", "dbo.Servers");
            DropForeignKey("dbo.ServerServerCategories", "ServerCategory_Id", "dbo.ServerCategories");
            DropIndex("dbo.ServerServerCategories", new[] { "Server_Id" });
            DropIndex("dbo.ServerServerCategories", new[] { "ServerCategory_Id" });
            AddColumn("dbo.Servers", "ServerCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Servers", "ServerCategoryId");
            AddForeignKey("dbo.Servers", "ServerCategoryId", "dbo.ServerCategories", "Id", cascadeDelete: true);
            DropTable("dbo.ServerServerCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServerServerCategories",
                c => new
                    {
                        Server_Id = c.Int(nullable: false),
                        ServerCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Server_Id, t.ServerCategory_Id });
            
            DropForeignKey("dbo.Servers", "ServerCategoryId", "dbo.ServerCategories");
            DropIndex("dbo.Servers", new[] { "ServerCategoryId" });
            DropColumn("dbo.Servers", "ServerCategoryId");
            CreateIndex("dbo.ServerServerCategories", "ServerCategory_Id");
            CreateIndex("dbo.ServerServerCategories", "Server_Id");
            AddForeignKey("dbo.ServerServerCategories", "ServerCategory_Id", "dbo.ServerCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ServerServerCategories", "Server_Id", "dbo.Servers", "Id", cascadeDelete: true);
        }
    }
}
