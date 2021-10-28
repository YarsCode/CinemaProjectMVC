namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedScreeningModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Screenings", "AvailableSeatsNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Screenings", "AvailableSeatsNumber");
        }
    }
}
