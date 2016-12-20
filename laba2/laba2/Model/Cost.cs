using System;

namespace laba2.Model
{
    public class Cost : BaseEntity
    {
        public string CostTitle { get; set; }

        public string Description { get; set; }

        public decimal Cash { get; set; }

        public DateTime Date { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
