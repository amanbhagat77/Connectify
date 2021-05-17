namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDEDFLAGINJOBS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "flag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "flag");
        }
    }
}
