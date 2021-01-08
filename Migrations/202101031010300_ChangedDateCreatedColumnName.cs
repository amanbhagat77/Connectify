namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateCreatedColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Jobs", "DateJobeCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "DateJobeCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Jobs", "DateCreated");
        }
    }
}
