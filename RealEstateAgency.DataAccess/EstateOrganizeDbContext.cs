using RealEstateAgency.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RealEstateAgency.DataAccess
{
    public class EstateOrganizeDbContext:DbContext
    {
        public EstateOrganizeDbContext():base("RealEstateAgencyDBConnection")
        {

        }

        public DbSet<Estate> Estates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
