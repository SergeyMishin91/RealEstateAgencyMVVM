using System.Threading.Tasks;

namespace RealEstateAgency.UI.ViewModel
{
    public interface IEstateDetailViewModel
    {
        Task LoadAsync(int estateId);
    }
}