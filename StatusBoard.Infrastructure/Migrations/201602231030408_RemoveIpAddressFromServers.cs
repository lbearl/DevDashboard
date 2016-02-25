namespace StatusBoard.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIpAddressFromServers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Servers", "IpAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servers", "IpAddress", c => c.String());
        }
    }
}
