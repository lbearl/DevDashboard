namespace StatusBoard.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class BaseObjectTracking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servers", "DateCreated", c => c.DateTime());
            AddColumn("dbo.Servers", "UserCreated", c => c.String());
            AddColumn("dbo.Servers", "DateModified", c => c.DateTime());
            AddColumn("dbo.Servers", "UserModified", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Servers", "UserModified");
            DropColumn("dbo.Servers", "DateModified");
            DropColumn("dbo.Servers", "UserCreated");
            DropColumn("dbo.Servers", "DateCreated");
        }
    }
}
