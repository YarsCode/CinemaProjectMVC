namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToSeatModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "CinemaId" });
            AlterColumn("dbo.Seats", "CinemaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Seats", "CinemaId");
            AddForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "CinemaId" });
            AlterColumn("dbo.Seats", "CinemaId", c => c.Int());
            CreateIndex("dbo.Seats", "CinemaId");
            AddForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas", "Id");
        }
    }
}
