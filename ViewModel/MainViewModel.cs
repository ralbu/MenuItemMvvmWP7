using System.ComponentModel;

namespace MenuItemMvvm.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _isCheckBoxSelected;
        private bool _isMenuEnabled;

        public MainViewModel()
        {
            IsCheckBoxSelected = true;
        }

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public bool IsCheckBoxSelected
        {
            get { return _isCheckBoxSelected; }
            set
            {
                if (_isCheckBoxSelected == value) return;
                
                _isCheckBoxSelected = value;
                
                IsMenuEnabled = _isCheckBoxSelected;
                OnPropertyChanged("IsCheckBoxSelected");
            }
        }

        public bool IsMenuEnabled
        {
            get
            {
                return _isMenuEnabled;
            }
            set
            {
                if (_isMenuEnabled == value) return;

                _isMenuEnabled = value;
                OnPropertyChanged("IsMenuEnabled");
            }
        }
    }
}
