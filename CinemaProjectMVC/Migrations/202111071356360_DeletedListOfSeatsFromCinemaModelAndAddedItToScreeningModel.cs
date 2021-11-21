namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedListOfSeatsFromCinemaModelAndAddedItToScreeningModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Screenings", "AvailableSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Screenings", "AvailableSeats", c => c.Int(nullable: false));
        }
    }
}
