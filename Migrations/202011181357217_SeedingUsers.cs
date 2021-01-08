namespace Connectify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'60caa2ca-0214-418c-8935-8aeba1d9f63d', N'Admin')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4e3b9487-b43e-4460-bcec-4eb724ebb713', N'admin@connectify.com', 0, N'AAovQp6jPdWLkRa2LK2+LPv8offnZIi175Y2HPOU93pI6LCKz7nyRyNFAX6Mr+Etmg==', N'e5e6c559-1c1e-4e98-b015-5a9e6bed80e0', NULL, 0, 0, NULL, 1, 0, N'admin@connectify.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a919c1dd-e5f6-4727-8615-b7ac98d5aca3', N'guest@connectify.com', 0, N'AJuePi5WfwLme+O0kXwzsIekCBl6AjKratfz6PWdr3LeE/UyE27ClfEL7mJCPzHPDw==', N'e568e4b6-2765-4fbe-bc44-ad013d7bec11', NULL, 0, 0, NULL, 1, 0, N'guest@connectify.com')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4e3b9487-b43e-4460-bcec-4eb724ebb713', N'60caa2ca-0214-418c-8935-8aeba1d9f63d')

");
        }
        
        public override void Down()
        {
        }
    }
}
