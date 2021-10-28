namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToSeatModel3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "CinemaId" });
            DropPrimaryKey("dbo.Seats");
            AddColumn("dbo.Seats", "Cinema_Id", c => c.Int());
            AlterColumn("dbo.Seats", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Seats", "CinemaId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Seats", "Id");
            CreateIndex("dbo.Seats", "Cinema_Id");
            AddForeignKey("dbo.Seats", "Cinema_Id", "dbo.Cinemas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "Cinema_Id" });
            DropPrimaryKey("dbo.Seats");
            AlterColumn("dbo.Seats", "CinemaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Seats", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Seats", "Cinema_Id");
            AddPrimaryKey("dbo.Seats", "Id");
            CreateIndex("dbo.Seats", "CinemaId");
            AddForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas", "Id", cascadeDelete: true);
        }
    }
}
