using RealEstateAgency.Model;
using RealEstateAgency.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RealEstateAgency.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //private IEstateDataService estateDataService;
        //private Estate selectedEstate;

        //public MainViewModel(IEstateDataService estateDataService)
        //{
        //    Estates = new ObservableCollection<Estate>();
        //    this.estateDataService = estateDataService;
        //}

        public MainViewModel(INavigationViewModel navigationViewModel,
            IEstateDetailViewModel estateDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            EstateDetailViewModel = estateDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();

            //var estates = await estateDataService.GetAllAsync();
            //Estates.Clear();
            //foreach (var estate in estates)
            //{
            //    Estates.Add(estate);
            //}
        }

        public INavigationViewModel NavigationViewModel { get; }
        public IEstateDetailViewModel EstateDetailViewModel { get; }

        //public ObservableCollection<Estate> Estates { get; set; }

        //public Estate SelectedEstate
        //{
        //    get { return selectedEstate; }
        //    set
        //    {
        //        selectedEstate = value;
        //        //в данном случае будет вызываться SelectedEstate
        //        OnPropertyChanged();
        //    }
        //}
    }
}
