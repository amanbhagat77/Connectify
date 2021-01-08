namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobActivityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        EngineerId = c.String(maxLength: 128),
                        Status = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.EngineerId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.EngineerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobActivities", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.JobActivities", "EngineerId", "dbo.AspNetUsers");
            DropIndex("dbo.JobActivities", new[] { "EngineerId" });
            DropIndex("dbo.JobActivities", new[] { "JobId" });
            DropTable("dbo.JobActivities");
        }
    }
}
