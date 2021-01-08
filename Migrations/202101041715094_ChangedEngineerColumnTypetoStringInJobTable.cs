namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEngineerColumnTypetoStringInJobTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "EngineerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "EngineerId", c => c.Int(nullable: false));
        }
    }
}
