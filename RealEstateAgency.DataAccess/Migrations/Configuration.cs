namespace RealEstateAgency.DataAccess.Migrations
{
    using RealEstateAgency.Model;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RealEstateAgency.DataAccess.EstateOrganizeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RealEstateAgency.DataAccess.EstateOrganizeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Estates.AddOrUpdate(
                e => e.EstateID,
                new Estate { EstateID = 1, EstateName = "капитальное строение", EstateAdress = "Минск", EstateSpace = 13.5, EstateCostOfSale = 25000 },
                new Estate { EstateID = 2, EstateName = "капитальное строение", EstateAdress = "Бобруйск", EstateSpace = 978.1, EstateCostOfSale = 60784 },
                new Estate { EstateID = 3, EstateName = "капитальное строение", EstateAdress = "Борисов", EstateSpace = 1113.2, EstateCostOfSale = 120126 }
                );
        }
    }
}
