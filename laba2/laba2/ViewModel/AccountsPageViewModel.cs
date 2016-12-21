using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using laba2.Model;
using laba2.Services;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Linq;

namespace laba2.ViewModel
{
    public class AccountsPageViewModel : ViewModelBase
    {
        private ObservableCollection<Account> accounts;

        public ObservableCollection<Account> Accounts
        {
            get { return accounts; }
            set
            {
                if (accounts == value) return;
                accounts = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand Navigate { get; set; }

        public RelayCommand<int> Details { get; set; }

        public RelayCommand<int> Delete { get; set; }

        private IRepository<Account> repository;

        public AccountsPageViewModel()
        {
            this.repository = new Repository<Account>();
            this.Accounts = new ObservableCollection<Account>(this.repository.GetAll());
            this.Navigate = new RelayCommand(() => Messenger.Default.Send<string>("addAccount"));
            this.Details = new RelayCommand<int>(id => Messenger.Default.Send<int>(id));
            this.Delete = new RelayCommand<int>(DeleteAction);
        }

        private void DeleteAction(int id)
        {
            this.Accounts.Remove(this.Accounts.First(x => x.Id == id));
            this.repository.Delete(id);
            this.repository.SaveChanged();
        }
    }
}