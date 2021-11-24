namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'976b4a85-ccec-4b2f-9203-be078c28a9f0', N'admin@cinema.com', 0, N'AI9UdWJtcpG7aPEZ4ehbRYlYZhtBLj+zzyf0ls8qlHQAXwGW0Vch2O+py8lMiCNA2A==', N'5851de30-4af6-485b-b544-bfaebaf4f28c', NULL, 0, 0, NULL, 1, 0, N'admin@cinema.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'70b44146-8b46-472d-b198-d98c922e8db0', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'976b4a85-ccec-4b2f-9203-be078c28a9f0', N'70b44146-8b46-472d-b198-d98c922e8db0')
");
        }
        
        public override void Down()
        {
        }
    }
}
