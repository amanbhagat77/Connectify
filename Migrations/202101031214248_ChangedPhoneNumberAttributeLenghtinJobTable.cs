namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPhoneNumberAttributeLenghtinJobTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
