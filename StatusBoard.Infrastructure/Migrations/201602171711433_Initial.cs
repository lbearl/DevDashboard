namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servers", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Servers", "Hostname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servers", "Hostname", c => c.String());
            DropColumn("dbo.Servers", "IsActive");
        }
    }
}
