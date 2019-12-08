namespace Blood_Pressure_Tracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blood_Pressure_Tracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Blood_Pressure_Tracker.Models.ApplicationDbContext";
        }

        protected override void Seed(Blood_Pressure_Tracker.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
