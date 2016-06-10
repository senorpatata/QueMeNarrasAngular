using System.Data.Entity.Migrations;

namespace QUEMENARRASANGULAR.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<QUEMENARRASANGULAR.EntityFramework.QUEMENARRASANGULARDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "QUEMENARRASANGULAR";
        }

        protected override void Seed(QUEMENARRASANGULAR.EntityFramework.QUEMENARRASANGULARDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
