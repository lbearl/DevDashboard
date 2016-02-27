namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServerCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryColor = c.Int(nullable: false),
                        Server_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Servers", t => t.Server_Id)
                .Index(t => t.Server_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServerCategories", "Server_Id", "dbo.Servers");
            DropIndex("dbo.ServerCategories", new[] { "Server_Id" });
            DropTable("dbo.ServerCategories");
        }
    }
}
