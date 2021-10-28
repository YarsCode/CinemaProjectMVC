namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToSeatModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "Cinema_Id" });
            RenameColumn(table: "dbo.Seats", name: "Cinema_Id", newName: "CinemaId");
            AlterColumn("dbo.Seats", "CinemaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Seats", "CinemaId");
            AddForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "CinemaId" });
            AlterColumn("dbo.Seats", "CinemaId", c => c.Int());
            RenameColumn(table: "dbo.Seats", name: "CinemaId", newName: "Cinema_Id");
            CreateIndex("dbo.Seats", "Cinema_Id");
            AddForeignKey("dbo.Seats", "Cinema_Id", "dbo.Cinemas", "Id");
        }
    }
}
