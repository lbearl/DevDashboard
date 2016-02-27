namespace StatusBoard.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataModelFixes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servers", "Hostname", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Servers", "DisplayName", c => c.String(maxLength: 200));
            AlterColumn("dbo.ServiceHistories", "PingStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceHistories", "PingResponseTime", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceHistories", "SslCertificateStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceHistories", "SslCertificateStatus", c => c.String());
            AlterColumn("dbo.ServiceHistories", "PingResponseTime", c => c.String());
            AlterColumn("dbo.ServiceHistories", "PingStatus", c => c.String());
            AlterColumn("dbo.Servers", "DisplayName", c => c.String());
            AlterColumn("dbo.Servers", "Hostname", c => c.String(nullable: false));
        }
    }
}
