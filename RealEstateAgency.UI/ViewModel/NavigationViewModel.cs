using Prism.Events;
using RealEstateAgency.Model;
using RealEstateAgency.UI.Data;
using RealEstateAgency.UI.Event;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IEstateLookupDataService estateLookupService;
        private IEventAggregator eventAggregator;

        public NavigationViewModel(IEstateLookupDataService estateLookupService,
            IEventAggregator eventAggregator)
        {
            this.estateLookupService = estateLookupService;
            this.eventAggregator = eventAggregator;
            Estates = new ObservableCollection<NavigationItemViewModel>();
            eventAggregator.GetEvent<AfterEstateSaveEvent>()
                .Subscribe(AfterEstateSaved);
        }

        private void AfterEstateSaved(AfterEstateSavedEventArgs obj)
        {
            var lookupItem = Estates.Single(l => l.Id == obj.Id);
            lookupItem.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await estateLookupService.GetEstateLookupAsync();
            Estates.Clear();
            foreach (var item in lookup)
            {
                Estates.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Estates { get; }

        private NavigationItemViewModel selectedEstate;

        public NavigationItemViewModel SelectedEstate
        {
            get { return selectedEstate; }
            set
            {
                selectedEstate = value;
                OnPropertyChanged();
                if (selectedEstate!=null)
                {
                    eventAggregator.GetEvent<OpenEstateDetailViewEvent>()
                        .Publish(selectedEstate.Id);
                }
            }
        }

    }
}
