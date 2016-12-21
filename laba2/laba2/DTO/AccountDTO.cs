using GalaSoft.MvvmLight;
using laba2.Model;
using System.Collections.ObjectModel;

namespace laba2.DTO
{
    public class AccountDTO : ObservableObject
    {
        private int id;
        public int Id { get { return id; } set { Set(nameof(Id), ref id, value); } }

        private string name;
        public string Name { get { return name; } set { Set(nameof(Name), ref name, value); } }

        private decimal totalCash;
        public decimal TotalCash { get { return totalCash; } set { Set(nameof(TotalCash), ref totalCash, value); } }

        private decimal monthelyIncome;
        public decimal MonthlyIncome { get { return monthelyIncome; } set { Set(nameof(MonthlyIncome), ref monthelyIncome, value); } }

        private ObservableCollection<CostDTO> costs;
        public ObservableCollection<CostDTO> Costs
        {
            get { return costs; }
            set { Set(nameof(Costs), ref costs, value); }
        }

        private ObservableCollection<IncomeDTO> incomes;
        public ObservableCollection<IncomeDTO> Incomes
        {
            get { return incomes; }
            set { Set(nameof(Incomes), ref incomes, value); }
        }
    }
}