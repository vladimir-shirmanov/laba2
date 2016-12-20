using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using laba2.Model;
using laba2.Services;

namespace laba2.ViewModel
{
    public class AccountsPageViewModel : ViewModelBase
    {
        private ObservableCollection<Account> accounts;

        private ObservableCollection<Account> Accounts
        {
            get { return accounts; }
            set
            {
                accounts = value;
                RaisePropertyChanged();
            }
        }

        private IRepository<Account> repository;

        public AccountsPageViewModel()
        {
            this.repository = new Repository<Account>();
            FillCollection();
        }

        private void FillCollection()
        {
            this.Accounts = new ObservableCollection<Account>();
            var acc = this.repository.GetAll();
            foreach (var account in acc)
            {
                Accounts.Add(account);
            }
        }
    }
}
