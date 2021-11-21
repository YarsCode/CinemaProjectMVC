namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScreeningPropToSeatModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "ScreeningId", c => c.Int());
            CreateIndex("dbo.Seats", "ScreeningId");
            AddForeignKey("dbo.Seats", "ScreeningId", "dbo.Screenings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "ScreeningId", "dbo.Screenings");
            DropIndex("dbo.Seats", new[] { "ScreeningId" });
            DropColumn("dbo.Seats", "ScreeningId");
        }
    }
}
