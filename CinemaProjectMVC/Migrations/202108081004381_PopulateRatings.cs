namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRatings : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ratings (Id, Stars) VALUES (1, 1)");
            Sql("INSERT INTO Ratings (Id, Stars) VALUES (2, 2)");
            Sql("INSERT INTO Ratings (Id, Stars) VALUES (3, 3)");
            Sql("INSERT INTO Ratings (Id, Stars) VALUES (4, 4)");
            Sql("INSERT INTO Ratings (Id, Stars) VALUES (5, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
