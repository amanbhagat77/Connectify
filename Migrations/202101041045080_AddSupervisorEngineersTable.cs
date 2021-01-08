namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupervisorEngineersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupervisorEngineers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SupervisorId = c.Int(nullable: false),
                        EngineerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SupervisorEngineers");
        }
    }
}
