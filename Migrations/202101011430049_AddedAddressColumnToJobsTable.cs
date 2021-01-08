namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddressColumnToJobsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Address", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Jobs", "City", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Jobs", "State", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "State");
            DropColumn("dbo.Jobs", "City");
            DropColumn("dbo.Jobs", "Address");
        }
    }
}
