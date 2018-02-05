using RealEstateAgency.Model;
using RealEstateAgency.UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.UI.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private IEstateLookupDataService estateLookupService;

        public NavigationViewModel(IEstateLookupDataService estateLookupService)
        {
            this.estateLookupService = estateLookupService;
            Estates = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await estateLookupService.GetEstateLookupAsync();
            Estates.Clear();
            foreach (var item in lookup)
            {
                Estates.Add(item);
            }
        }

        public ObservableCollection<LookupItem> Estates { get; }
    }
}
