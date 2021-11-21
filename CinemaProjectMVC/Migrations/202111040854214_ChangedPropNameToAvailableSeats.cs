namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPropNameToAvailableSeats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Screenings", "AvailableSeats", c => c.Int(nullable: false));
            DropColumn("dbo.Screenings", "AvailableSeatsNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Screenings", "AvailableSeatsNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Screenings", "AvailableSeats");
        }
    }
}
