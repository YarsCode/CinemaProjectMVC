namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteScreeningIdFromSeatModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Screenings", "AvailableSeatsId", c => c.Byte(nullable: false));
            AddColumn("dbo.Seats", "Screening_Id", c => c.Int());
            CreateIndex("dbo.Seats", "Screening_Id");
            AddForeignKey("dbo.Seats", "Screening_Id", "dbo.Screenings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "Screening_Id", "dbo.Screenings");
            DropIndex("dbo.Seats", new[] { "Screening_Id" });
            DropColumn("dbo.Seats", "Screening_Id");
            DropColumn("dbo.Screenings", "AvailableSeatsId");
        }
    }
}
