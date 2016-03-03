namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "PhoneNumber");
        }
    }
}
