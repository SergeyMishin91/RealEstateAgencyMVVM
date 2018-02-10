using RealEstateAgency.UI.Data;
using RealEstateAgency.Model;
using System.Threading.Tasks;
using Prism.Events;
using RealEstateAgency.UI.Event;
using System;
using System.Windows.Input;
using Prism.Commands;
using RealEstateAgency.UI.Wrapper;

namespace RealEstateAgency.UI.ViewModel
{
    public class EstateDetailViewModel : ViewModelBase, IEstateDetailViewModel
    {
        private IEstateDataService dataService;
        private IEventAggregator eventAggregator;
        private EstateWrapper estate;

        public EstateDetailViewModel(IEstateDataService dataService,
            IEventAggregator eventAggregator)
        {
            this.dataService = dataService;
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<OpenEstateDetailViewEvent>()
                .Subscribe(OnOpenEstateDetailView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public async Task LoadAsync(int estateId)
        {
            var estate = await dataService.GetByIdAsync(estateId);

            Estate = new EstateWrapper(estate);

            Estate.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Estate.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        public EstateWrapper Estate
        {
            get { return estate; }
            private set
            {
                estate = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        private bool OnSaveCanExecute()
        {
            return Estate!=null && !Estate.HasErrors;
        }

        private async void OnSaveExecute()
        {
            await dataService.SaveAsync(Estate.Model);

            eventAggregator.GetEvent<AfterEstateSaveEvent>().Publish(
                new AfterEstateSavedEventArgs
                {
                    Id = Estate.Id,
                    DisplayMember = $"{Estate.EstateName}"
                });
                
        }

        private async void OnOpenEstateDetailView(int estateId)
        {
            await LoadAsync(estateId);
        }

       
    }
}
