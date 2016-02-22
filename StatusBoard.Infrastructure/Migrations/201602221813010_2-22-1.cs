namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2221 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servers", "DisplayName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Servers", "DisplayName");
        }
    }
}
