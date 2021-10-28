namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInCinemaModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "Screening_Id", "dbo.Screenings");
            DropForeignKey("dbo.Seats", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "Cinema_Id" });
            DropIndex("dbo.Seats", new[] { "Screening_Id" });
            DropColumn("dbo.Seats", "CinemaId");
            RenameColumn(table: "dbo.Seats", name: "Cinema_Id", newName: "CinemaId");
            AddColumn("dbo.Cinemas", "NumberOfSeats", c => c.Int(nullable: false));
            AlterColumn("dbo.Seats", "CinemaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Seats", "CinemaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Seats", "CinemaId");
            AddForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas", "Id", cascadeDelete: true);
            DropColumn("dbo.Cinemas", "TotalSeatsNumber");
            DropColumn("dbo.Seats", "Screening_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "Screening_Id", c => c.Int());
            AddColumn("dbo.Cinemas", "TotalSeatsNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "CinemaId" });
            AlterColumn("dbo.Seats", "CinemaId", c => c.Int());
            AlterColumn("dbo.Seats", "CinemaId", c => c.Byte(nullable: false));
            DropColumn("dbo.Cinemas", "NumberOfSeats");
            RenameColumn(table: "dbo.Seats", name: "CinemaId", newName: "Cinema_Id");
            AddColumn("dbo.Seats", "CinemaId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Seats", "Screening_Id");
            CreateIndex("dbo.Seats", "Cinema_Id");
            AddForeignKey("dbo.Seats", "Cinema_Id", "dbo.Cinemas", "Id");
            AddForeignKey("dbo.Seats", "Screening_Id", "dbo.Screenings", "Id");
        }
    }
}
