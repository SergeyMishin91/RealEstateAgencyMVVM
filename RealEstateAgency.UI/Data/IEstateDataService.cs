using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstateAgency.Model;

namespace RealEstateAgency.UI.Data
{
    public interface IEstateDataService
    {
        Task<Estate> GetByIdAsync(int estateId);
        Task SaveAsync(Estate estate);
    }
}