using RealEstateAgency.DataAccess;
using RealEstateAgency.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.UI.Data
{
    public class LookupDataService : IEstateLookupDataService
    {
        private Func<EstateOrganizeDbContext> contextCreator;

        public LookupDataService(Func<EstateOrganizeDbContext> contextCreator)
        {
            this.contextCreator = contextCreator;
        }

        public async Task <IEnumerable<LookupItem>> GetEstateLookupAsync()
        {
            using (var ctx = contextCreator())
            {
                return await ctx.Estates.AsNoTracking()
                    .Select(e =>
                    new LookupItem
                    {
                        Id = e.EstateID,
                        DisplayMember = e.EstateName
                    })
                    .ToListAsync();
            }
        }
    }
}
