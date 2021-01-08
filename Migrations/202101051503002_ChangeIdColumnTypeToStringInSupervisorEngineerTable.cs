namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdColumnTypeToStringInSupervisorEngineerTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SupervisorEngineers", "SupervisorId", c => c.String(nullable: false));
            AlterColumn("dbo.SupervisorEngineers", "EngineerId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SupervisorEngineers", "EngineerId", c => c.Int(nullable: false));
            AlterColumn("dbo.SupervisorEngineers", "SupervisorId", c => c.Int(nullable: false));
        }
    }
}
