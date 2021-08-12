namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateScreeningTimes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ScreeningTimes (Id, Time, isAvailable) VALUES (1, '12:00', 1)");
            Sql("INSERT INTO ScreeningTimes (Id, Time, isAvailable) VALUES (2, '13:30', 1)");
            Sql("INSERT INTO ScreeningTimes (Id, Time, isAvailable) VALUES (3, '15:00', 1)");
            Sql("INSERT INTO ScreeningTimes (Id, Time, isAvailable) VALUES (4, '16:30', 1)");
            Sql("INSERT INTO ScreeningTimes (Id, Time, isAvailable) VALUES (5, '18:00', 1)");
            Sql("INSERT INTO ScreeningTimes (Id, Time, isAvailable) VALUES (6, '19:30', 1)");
            Sql("INSERT INTO ScreeningTimes (Id, Time, isAvailable) VALUES (7, '21:00', 1)");
            Sql("INSERT INTO ScreeningTimes (Id, Time, isAvailable) VALUES (8, '22:30', 1)");
            Sql("INSERT INTO ScreeningTimes (Id, Time, isAvailable) VALUES (9, '00:00', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
