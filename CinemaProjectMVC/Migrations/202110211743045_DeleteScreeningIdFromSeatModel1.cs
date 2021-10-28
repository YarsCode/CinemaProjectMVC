namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteScreeningIdFromSeatModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "Screening_Id", "dbo.Screenings");
            //DropIndex("dbo.Seats", new[] { "Screening_Id" });
            DropColumn("dbo.Screenings", "AvailableSeatsId");
            //DropColumn("dbo.Seats", "Screening_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Seats", "Screening_Id", c => c.Int());
            AddColumn("dbo.Screenings", "AvailableSeatsId", c => c.Byte(nullable: false));
            //CreateIndex("dbo.Seats", "Screening_Id");
            //AddForeignKey("dbo.Seats", "Screening_Id", "dbo.Screenings", "Id");
        }
    }
}
