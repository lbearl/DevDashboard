namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveServerCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Servers", "ServerCategoryId", "dbo.ServerCategories");
            DropIndex("dbo.Servers", new[] { "ServerCategoryId" });
            RenameColumn(table: "dbo.Servers", name: "ServerCategoryId", newName: "ServerCategory_Id");
            AlterColumn("dbo.Servers", "ServerCategory_Id", c => c.Int());
            CreateIndex("dbo.Servers", "ServerCategory_Id");
            AddForeignKey("dbo.Servers", "ServerCategory_Id", "dbo.ServerCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servers", "ServerCategory_Id", "dbo.ServerCategories");
            DropIndex("dbo.Servers", new[] { "ServerCategory_Id" });
            AlterColumn("dbo.Servers", "ServerCategory_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Servers", name: "ServerCategory_Id", newName: "ServerCategoryId");
            CreateIndex("dbo.Servers", "ServerCategoryId");
            AddForeignKey("dbo.Servers", "ServerCategoryId", "dbo.ServerCategories", "Id", cascadeDelete: true);
        }
    }
}
