namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOpeningAndClosingHours : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO OpeningHours (Id, Time) VALUES (1, '10:00')");
            Sql("INSERT INTO OpeningHours (Id, Time) VALUES (2, '11:00')");
            Sql("INSERT INTO OpeningHours (Id, Time) VALUES (3, '12:00')");
            Sql("INSERT INTO OpeningHours (Id, Time) VALUES (4, '13:00')");
            Sql("INSERT INTO OpeningHours (Id, Time) VALUES (5, '14:00')");

            Sql("INSERT INTO ClosingHours (Id, Time) VALUES (1, '22:00')");
            Sql("INSERT INTO ClosingHours (Id, Time) VALUES (2, '23:00')");
            Sql("INSERT INTO ClosingHours (Id, Time) VALUES (3, '00:00')");
            Sql("INSERT INTO ClosingHours (Id, Time) VALUES (4, '01:00')");
            Sql("INSERT INTO ClosingHours (Id, Time) VALUES (5, '02:00')");
        }
        
        public override void Down()
        {
        }
    }
}
