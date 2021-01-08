namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNameApplicationUser : DbMigration
    {
        public override void Up()
        {
            Sql("Update AspNetUsers set PhoneNumber = '8285588515'");
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
        }
    }
}
