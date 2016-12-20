using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using laba2.ViewModel;

namespace laba2
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region menu pages
        private StartPageViewModel startPageViewModel = new StartPageViewModel();
        private AccountsPageViewModel accountsPageViewModel = new AccountsPageViewModel();
        #endregion

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { Set(nameof(CurrentViewModel), ref _currentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            CurrentViewModel = startPageViewModel;
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "startPage":
                    CurrentViewModel = startPageViewModel;
                    break;
                case "accounts":
                    CurrentViewModel = accountsPageViewModel;
                    break;
                default:
                    break;
            }
        }
    }
}