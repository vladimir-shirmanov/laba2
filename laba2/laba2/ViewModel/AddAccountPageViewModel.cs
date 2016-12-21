using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using laba2.DTO;
using laba2.Model;
using laba2.Services;

namespace laba2.ViewModel
{
    public class AddAccountPageViewModel : ViewModelBase
    {
        private IRepository<Account> repository;
        private AccountDTO account;

        public AccountDTO Account
        {
            get { return account; }
            set { Set(nameof(Account), ref account, value); }
        }

        public RelayCommand Save { get; private set; }

        public AddAccountPageViewModel()
        {
            this.repository = new Repository<Account>();
            this.Account = new AccountDTO();
            this.Save = new RelayCommand(() =>
            {
                this.repository.Add(new Account
                {
                    Name = this.Account.Name,
                    MonthlyIncome = this.Account.MonthlyIncome,
                    TotalCash = this.Account.TotalCash
                });
                this.repository.SaveChanged();
                Messenger.Default.Send<string>("accounts");
            });
        }
    }
}