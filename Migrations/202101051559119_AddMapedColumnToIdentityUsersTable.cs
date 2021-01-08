namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMapedColumnToIdentityUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Mapped", c => c.Boolean(nullable: false));
            Sql("Update dbo.AspNetUsers set Mapped = 'false'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Mapped");
        }
    }
}
