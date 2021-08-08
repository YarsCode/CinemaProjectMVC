namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRatingNameToStars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "Stars", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Ratings", "Stars");
        }
    }
}
