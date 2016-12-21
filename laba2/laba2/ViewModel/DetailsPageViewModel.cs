using GalaSoft.MvvmLight;
using laba2.DTO;
using laba2.Model;
using laba2.Services;
using System.Linq;
using System.Collections.ObjectModel;
using System;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;

namespace laba2.ViewModel
{
    public class DetailsPageViewModel : ViewModelBase
    {
        private AccountDTO account;

        public AccountDTO Account
        {
            get { return account; }
            set { Set(nameof(Account), ref account, value); }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set {
                if (startDate == value) return;
                Account.Incomes = ResetCollection<IncomeDTO>(Account.Incomes, x => x.Date >= value && x.Date <= EndDate);
                Account.Costs = ResetCollection<CostDTO>(Account.Costs, x => x.Date >= value && x.Date <= EndDate);
                startDate = value;
                RaisePropertyChanged();
            }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set {
                if (endDate == value) return;
                Account.Incomes = ResetCollection<IncomeDTO>(Account.Incomes, x => x.Date >= StartDate && x.Date <= value);
                Account.Costs = ResetCollection<CostDTO>(Account.Costs, x => x.Date >= StartDate && x.Date <= value);
                endDate = value; }
        }

        private bool fullPeriod;

        public bool FullPeriod
        {
            get { return fullPeriod; }
            set {
                if (fullPeriod == value) return;
                var dbEntity = accountRepository.GetById(Account.Id);
                Account.Incomes = MapToIncomeDto(dbEntity.Incomes);
                Account.Costs = MapToCostDto(dbEntity.Costs);
                fullPeriod = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<object> UpdateIncomes { get; set; }

        public RelayCommand<object> UpdateCosts { get; set; }

        private IRepository<Account> accountRepository;
        private IRepository<Income> incomeRepository;
        private IRepository<Cost> costRepository;

        public DetailsPageViewModel(int id)
        {
            this.accountRepository = new Repository<Account>();
            this.incomeRepository = new Repository<Income>();
            this.costRepository = new Repository<Cost>();

            Account = this.GetAccountDto(this.accountRepository.GetById(id));
            FullPeriod = true;
            startDate = DateTime.Now;
            endDate = DateTime.Now.AddDays(1);

            UpdateCosts = new RelayCommand<object>(UpdateCostsAction);
            UpdateIncomes = new RelayCommand<object>(UpdateIncomesAction);
        }


        private AccountDTO GetAccountDto(Account account)
        {
            return new AccountDTO
            {
                Id = account.Id,
                Name = account.Name,
                MonthlyIncome = account.MonthlyIncome,
                TotalCash = account.TotalCash,
                Costs = this.MapToCostDto(account.Costs),
                Incomes = this.MapToIncomeDto(account.Incomes)
            };
        }

        private ObservableCollection<IncomeDTO> MapToIncomeDto(Collection<Income> incomes)
        {
            return new ObservableCollection<IncomeDTO>(incomes.Select(x => new IncomeDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Cash = x.Cash,
                Date = x.Date
            }));
        }

        private ObservableCollection<CostDTO> MapToCostDto(Collection<Cost> costs)
        {
            return new ObservableCollection<CostDTO>(costs.Select(x => new CostDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Cash = x.Cash,
                Date = x.Date
            }));
        }

        private Income MapToIncome(IncomeDTO income)
        {
            return new Income
            {
                Id = income.Id,
                Name = income.Name,
                Description = income.Description,
                Date = income.Date,
                AccountId = Account.Id,
                Cash = income.Cash
            };
        }

        private Cost MapToCost(CostDTO cost)
        {
            return new Cost
            {
                Id = cost.Id,
                Name = cost.Name,
                Description = cost.Description,
                Date = cost.Date,
                AccountId = Account.Id,
                Cash = cost.Cash
            };
        }

        private ObservableCollection<T> ResetCollection<T>(ObservableCollection<T> collection, Func<T, bool> expr)
        {
            return new ObservableCollection<T>(collection.Where(expr));
        }

        private void UpdateIncomesAction(object obj)
        {
            var items = (IList)obj;
            var list = items.Cast<IncomeDTO>();

            var acc = this.accountRepository.GetById(Account.Id);
            foreach (var income in list)
            {
                this.incomeRepository.AddOrUpdate(this.MapToIncome(income));
            }

            this.incomeRepository.SaveChanged();
            Debug.WriteLine("incomes succesfully saved");
        }


        private void UpdateCostsAction(object obj)
        {
            var items = (IList)obj;
            var list = items.Cast<CostDTO>();

            foreach (var cost in list)
            {
                this.costRepository.AddOrUpdate(this.MapToCost(cost));
            }

            this.costRepository.SaveChanged();
            Debug.WriteLine("costs succesfully saved");
        }
    }
}