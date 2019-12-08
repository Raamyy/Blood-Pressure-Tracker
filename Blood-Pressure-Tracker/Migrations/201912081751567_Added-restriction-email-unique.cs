namespace Blood_Pressure_Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedrestrictionemailunique : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE AspNetUsers ADD UNIQUE (Email);");
        }
        
        public override void Down()
        {
        }
    }
}
