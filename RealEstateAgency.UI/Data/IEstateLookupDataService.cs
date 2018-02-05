using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateAgency.Model;

namespace RealEstateAgency.UI.Data
{
    public interface IEstateLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetEstateLookupAsync();
    }
}