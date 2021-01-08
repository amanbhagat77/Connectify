namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEngineerIdColumnInJobsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "EngineerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "EngineerId");
        }
    }
}
