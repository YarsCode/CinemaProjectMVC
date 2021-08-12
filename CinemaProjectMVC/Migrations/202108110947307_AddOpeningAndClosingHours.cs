namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOpeningAndClosingHours : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClosingHours",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Time = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpeningHours",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Time = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cinemas", "OpeningHourId", c => c.Byte(nullable: false));
            AddColumn("dbo.Cinemas", "ClosingHourId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cinemas", "OpeningHourId");
            CreateIndex("dbo.Cinemas", "ClosingHourId");
            AddForeignKey("dbo.Cinemas", "ClosingHourId", "dbo.ClosingHours", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cinemas", "OpeningHourId", "dbo.OpeningHours", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cinemas", "OpeningHourId", "dbo.OpeningHours");
            DropForeignKey("dbo.Cinemas", "ClosingHourId", "dbo.ClosingHours");
            DropIndex("dbo.Cinemas", new[] { "ClosingHourId" });
            DropIndex("dbo.Cinemas", new[] { "OpeningHourId" });
            DropColumn("dbo.Cinemas", "ClosingHourId");
            DropColumn("dbo.Cinemas", "OpeningHourId");
            DropTable("dbo.OpeningHours");
            DropTable("dbo.ClosingHours");
        }
    }
}
