namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingIdToMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Rating_Id", "dbo.Ratings");
            DropIndex("dbo.Movies", new[] { "Rating_Id" });
            RenameColumn(table: "dbo.Movies", name: "Rating_Id", newName: "RatingId");
            AlterColumn("dbo.Movies", "RatingId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "RatingId");
            AddForeignKey("dbo.Movies", "RatingId", "dbo.Ratings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Movies", new[] { "RatingId" });
            AlterColumn("dbo.Movies", "RatingId", c => c.Byte());
            RenameColumn(table: "dbo.Movies", name: "RatingId", newName: "Rating_Id");
            CreateIndex("dbo.Movies", "Rating_Id");
            AddForeignKey("dbo.Movies", "Rating_Id", "dbo.Ratings", "Id");
        }
    }
}
