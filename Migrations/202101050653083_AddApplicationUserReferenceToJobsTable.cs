namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserReferenceToJobsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "EngineerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jobs", "EngineerId");
            AddForeignKey("dbo.Jobs", "EngineerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "EngineerId", "dbo.AspNetUsers");
            DropIndex("dbo.Jobs", new[] { "EngineerId" });
            AlterColumn("dbo.Jobs", "EngineerId", c => c.String());
        }
    }
}
