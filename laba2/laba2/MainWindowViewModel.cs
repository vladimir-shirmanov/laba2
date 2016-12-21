using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using laba2.ViewModel;
using System.Diagnostics;

namespace laba2
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region menu pages
        private StartPageViewModel startPageViewModel = new StartPageViewModel();
        private AccountsPageViewModel accountsPageViewModel = new AccountsPageViewModel();
        private AddAccountPageViewModel addAccountPageViewModel = new AddAccountPageViewModel();
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
            Messenger.Default.Register<string>(this, OnNav);
            Messenger.Default.Register<int>(this, DetailsPage);
        }

        private void DetailsPage(int id)
        {
            Debug.WriteLine($"details page is called. Parameter destination = {id}");
            CurrentViewModel = new DetailsPageViewModel(id);
        }

        private void OnNav(string destination)
        {
            Debug.WriteLine($"On nav is called. Parameter destination = {destination}");
            switch (destination)
            {
                case "startPage":
                    CurrentViewModel = startPageViewModel;
                    break;
                case "accounts":
                    CurrentViewModel = accountsPageViewModel;
                    break;
                case "addAccount":
                    CurrentViewModel = addAccountPageViewModel;
                    break;
                default:
                    break;
            }
        }
    }
}