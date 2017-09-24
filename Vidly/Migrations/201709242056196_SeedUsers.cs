namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [Phone], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'df636c87-d0f1-46c3-9410-9af9a6c09e4f', N'guest@vidly.com', 0, N'ANhbwlcJloR7LSOG62wWm6LmKdrBQIBX2JUZcXQqpOPDdv/OBDzWwaQXva2ZTgftOg==', N'19bd3063-ff65-45b8-85fc-b7f8653a3bf5', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [Phone], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f3d32178-97e0-419f-a5a0-310da45c1f46', N'newadmin@vidly.com', 0, N'AOVXLQNUeXWlQdb3hhSu8d12o01KxLkCGGbkeOMCthXut4+iIZ7tn+reDAqSpdUl/w==', N'91e4a727-08da-405e-8c46-0747e532e578', NULL, 0, 0, NULL, 1, 0, N'newadmin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'91dff848-cb83-4864-87f3-386ab4bcac34', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f3d32178-97e0-419f-a5a0-310da45c1f46', N'91dff848-cb83-4864-87f3-386ab4bcac34')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
