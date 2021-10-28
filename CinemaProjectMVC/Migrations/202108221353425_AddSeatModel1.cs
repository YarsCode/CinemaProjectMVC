namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeatModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "Screening_Id", c => c.Int());
            CreateIndex("dbo.Seats", "Screening_Id");
            AddForeignKey("dbo.Seats", "Screening_Id", "dbo.Screenings", "Id");
            DropColumn("dbo.Screenings", "AvailableSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Screenings", "AvailableSeats", c => c.Int(nullable: false));
            DropForeignKey("dbo.Seats", "Screening_Id", "dbo.Screenings");
            DropIndex("dbo.Seats", new[] { "Screening_Id" });
            DropColumn("dbo.Seats", "Screening_Id");
        }
    }
}
