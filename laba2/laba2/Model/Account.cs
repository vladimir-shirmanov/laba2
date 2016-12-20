using System.Collections.ObjectModel;

namespace laba2.Model
{
    public class Account : BaseEntity
    {
        public decimal TotalCash { get; set; }

        public decimal MonthlyIncome { get; set; }

        public virtual Collection<Cost> Costs { get; set; }

        public virtual Collection<Income> Incomes { get; set; }
    }
}