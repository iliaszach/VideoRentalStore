namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'698f6e54-0ebd-4daf-bb09-f6623e193007', N'admin@ilias.com', 0, N'AEDwNRzlJR3ftvIdQx6+G92rCSkKFiBEg9Jo8aT1iJN3SmbBGHVoe2mnThAALptyTA==', N'c9180d7c-3d9b-43b9-8e21-a8765dc2a327', NULL, 0, 0, NULL, 1, 0, N'admin@ilias.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fb903801-b69a-4bc6-b1aa-8b4d60e6bb0b', N'guest@ilias.com', 0, N'AJF5iFczmoGsPeO4lqc4KcT/Jke8qYuZthPAKUelvNFknCJlkv/bQgEH7TyKA7uscg==', N'b7262eec-93a9-4e15-847b-a3aff90aa560', NULL, 0, 0, NULL, 1, 0, N'guest@ilias.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'17307fd4-a7d2-49fb-83e8-c75d8c2ed551', N'CanManageMovie')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'698f6e54-0ebd-4daf-bb09-f6623e193007', N'17307fd4-a7d2-49fb-83e8-c75d8c2ed551')
            ");
        }

        public override void Down()
        {
        }
    }
}
