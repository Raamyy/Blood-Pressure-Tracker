namespace Blood_Pressure_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPreasureMeasureToTUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PressureMeasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Systole = c.Int(nullable: false),
                        Diastole = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PressureMeasures", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PressureMeasures", new[] { "User_Id" });
            DropTable("dbo.PressureMeasures");
        }
    }
}
