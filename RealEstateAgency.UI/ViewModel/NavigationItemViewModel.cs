﻿namespace RealEstateAgency.UI.ViewModel
{
    public class NavigationItemViewModel:ViewModelBase
    {
        private string displayMember;

        public NavigationItemViewModel(int id, string displayMember)
        {
            Id = id;
            DisplayMember = displayMember;
        }

        public int Id { get; }
        public string DisplayMember
        {
            get { return this.displayMember; }
            set
            {
                this.displayMember = value;
                OnPropertyChanged();
            }
        }
    }
}