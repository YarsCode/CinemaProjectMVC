namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOpeningAndClosingHoursModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClosingHours", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OpeningHours", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OpeningHours", "Time", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ClosingHours", "Time", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
