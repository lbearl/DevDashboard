namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceHistoryRecordedOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceHistories", "RecordedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceHistories", "RecordedOn");
        }
    }
}
