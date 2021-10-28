namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSeatIDFromIntToByte : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Seats");
            AlterColumn("dbo.Seats", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Seats", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Seats");
            AlterColumn("dbo.Seats", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Seats", "Id");
        }
    }
}
