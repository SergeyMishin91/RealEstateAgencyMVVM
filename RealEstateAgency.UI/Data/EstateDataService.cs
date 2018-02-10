using RealEstateAgency.DataAccess;
using RealEstateAgency.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.UI.Data
{
    public class EstateDataService : IEstateDataService
    {
        private Func<EstateOrganizeDbContext> contextCreator;

        public EstateDataService(Func<EstateOrganizeDbContext> contextCreator)
        {
            this.contextCreator = contextCreator;
        }

        public async Task<Estate> GetByIdAsync(int estateId)
        {
            using (var ctx = contextCreator())
            {
                return await ctx.Estates.AsNoTracking()
                    .SingleAsync(e => e.EstateID == estateId);
            }
        }

        public async Task SaveAsync(Estate estate)
        {
            using (var ctx = contextCreator())
            {
                ctx.Estates.Attach(estate);
                ctx.Entry(estate).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
