namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllCategoryChanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ServerCategoryServers", newName: "ServerServerCategories");
            DropPrimaryKey("dbo.ServerServerCategories");
            AddPrimaryKey("dbo.ServerServerCategories", new[] { "Server_Id", "ServerCategory_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ServerServerCategories");
            AddPrimaryKey("dbo.ServerServerCategories", new[] { "ServerCategory_Id", "Server_Id" });
            RenameTable(name: "dbo.ServerServerCategories", newName: "ServerCategoryServers");
        }
    }
}
