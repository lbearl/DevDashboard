namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Is_Active_from_Server : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Servers", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servers", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
