using RealEstateAgency.UI.Data;
using RealEstateAgency.Model;
using System.Threading.Tasks;

namespace RealEstateAgency.UI.ViewModel
{
    public class EstateDetailViewModel : ViewModelBase, IEstateDetailViewModel
    {
        private IEstateDataService dataService;
        private Estate estate;

        public EstateDetailViewModel(IEstateDataService dataService)
        {
            this.dataService = dataService;
        }

        public Estate Estate
        {
            get { return estate; }
            private set
            {
                estate = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadAsync(int estateId)
        {
            Estate = await dataService.GetByIdAsync(estateId);
        }


    }
}
