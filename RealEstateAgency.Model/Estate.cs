using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RealEstateAgency.Model
{
    public class Estate : INotifyPropertyChanged
    {
        #region Estate fields
        private int estateID;
        //private string _estateFunction;
        private string _estateName;
        //private string _estateInventoryNumber;
        private double _estateSpace;
        private string _estateAdress;
        //private int _estateYear;
        //private string _estateWall;
        //private string _estateState;
        //private string _estateOwner;
        private double _estateCostOfSale;
        //private string _estateDescription;
        //private Image _photo;

        #endregion

        #region Estate properties

        public int EstateID
        {
            get { return estateID; }
            set
            {
                if (value == estateID) return;
                estateID = value;
                OnPropertyChanged();
            }
        }

        //public string EstateFunction
        //{
        //    get { return _estateFunction; }
        //    set
        //    {
        //        if (value == _estateFunction) return;
        //        _estateFunction = value;
        //        OnPropertyChanged();
        //    }
        //}
        [Required]
        [StringLength(30)]
        public string EstateName
        {
            get { return _estateName; }
            set
            {
                if (value == _estateName) return;
                _estateName = value;
                OnPropertyChanged();
            }
        }

        //public string EstateInventoryNumber
        //{
        //    get { return _estateInventoryNumber; }
        //    set
        //    {
        //        if (value == _estateInventoryNumber) return;
        //        _estateInventoryNumber = value;
        //        OnPropertyChanged();
        //    }
        //}

        public double EstateSpace
        {
            get { return _estateSpace; }
            set
            {
                if (value == _estateSpace) return;
                _estateSpace = value;
                OnPropertyChanged();
            }
        }

        public string EstateAdress
        {
            get { return _estateAdress; }
            set
            {
                if (value == _estateAdress) return;
                _estateAdress = value;
                OnPropertyChanged();
            }
        }

        //public int EstateYear
        //{
        //    get { return _estateYear; }
        //    set
        //    {
        //        if (value == _estateYear) return;
        //        _estateYear = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public string EstateWall
        //{
        //    get { return _estateWall; }
        //    set
        //    {
        //        if (value == _estateWall) return;
        //        _estateWall = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public string EstateState
        //{
        //    get { return _estateState; }
        //    set
        //    {
        //        if (value == _estateState) return;
        //        _estateState = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public string EstateOwner
        //{
        //    get { return _estateOwner; }
        //    set
        //    {
        //        if (value == _estateOwner) return;
        //        _estateOwner = value;
        //        OnPropertyChanged();
        //    }
        //}

        public double EstateCostOfSale
        {
            get { return _estateCostOfSale; }
            set
            {
                if (value == _estateCostOfSale) return;
                _estateCostOfSale = value;
                OnPropertyChanged();
            }
        }

        //public string EstateDescription
        //{
        //    get { return _estateDescription; }
        //    set
        //    {
        //        if (value == _estateDescription) return;
        //        _estateDescription = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public Image Photo { get; set; }
        #endregion

        public Estate() { }
        public Estate(int id, string name, double space, string adress, double cost)
        {
            estateID = id;
            _estateName = name;
            _estateSpace = space;
            _estateAdress = adress;
            _estateCostOfSale = cost;
            //_photo = photo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
