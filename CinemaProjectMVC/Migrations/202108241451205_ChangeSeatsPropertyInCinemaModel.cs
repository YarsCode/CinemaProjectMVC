namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSeatsPropertyInCinemaModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Seats");
            AddColumn("dbo.Cinemas", "TotalSeatsNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Seats", "Cinema_Id", c => c.Int());
            AlterColumn("dbo.Seats", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Seats", "Id");
            CreateIndex("dbo.Seats", "Cinema_Id");
            AddForeignKey("dbo.Seats", "Cinema_Id", "dbo.Cinemas", "Id");
            DropColumn("dbo.Cinemas", "TotalSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cinemas", "TotalSeats", c => c.Int(nullable: false));
            DropForeignKey("dbo.Seats", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "Cinema_Id" });
            DropPrimaryKey("dbo.Seats");
            AlterColumn("dbo.Seats", "Id", c => c.Byte(nullable: false));
            DropColumn("dbo.Seats", "Cinema_Id");
            DropColumn("dbo.Cinemas", "TotalSeatsNumber");
            AddPrimaryKey("dbo.Seats", "Id");
        }
    }
}
