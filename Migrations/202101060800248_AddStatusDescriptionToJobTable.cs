namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusDescriptionToJobTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Status", c => c.String());
            AddColumn("dbo.Jobs", "Description", c => c.String());
            DropColumn("dbo.JobActivities", "Status");
            DropColumn("dbo.JobActivities", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobActivities", "Description", c => c.String());
            AddColumn("dbo.JobActivities", "Status", c => c.String());
            DropColumn("dbo.Jobs", "Description");
            DropColumn("dbo.Jobs", "Status");
        }
    }
}
