namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCinemaModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cinemas", name: "ScreeningTime_Id", newName: "ScreeningTimeId");
            RenameIndex(table: "dbo.Cinemas", name: "IX_ScreeningTime_Id", newName: "IX_ScreeningTimeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cinemas", name: "IX_ScreeningTimeId", newName: "IX_ScreeningTime_Id");
            RenameColumn(table: "dbo.Cinemas", name: "ScreeningTimeId", newName: "ScreeningTime_Id");
        }
    }
}
