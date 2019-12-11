namespace Blood_Pressure_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedPressureMeasure : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PressureMeasures", new[] { "User_Id" });
            DropColumn("dbo.PressureMeasures", "UserId");
            RenameColumn(table: "dbo.PressureMeasures", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.PressureMeasures", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.PressureMeasures", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PressureMeasures", new[] { "UserId" });
            AlterColumn("dbo.PressureMeasures", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.PressureMeasures", name: "UserId", newName: "User_Id");
            AddColumn("dbo.PressureMeasures", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.PressureMeasures", "User_Id");
        }
    }
}
