// <auto-generated />
namespace StatusBoard.Infrastructure.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class AuditTracker : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AuditTracker));
        
        string IMigrationMetadata.Id
        {
            get { return "201603010749379_AuditTracker"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
