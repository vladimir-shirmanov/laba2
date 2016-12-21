using GalaSoft.MvvmLight;
using System;

namespace laba2.DTO
{
    public class IncomeDTO : ObservableObject
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { Set(nameof(Id), ref id, value); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { Set(nameof(Description), ref description, value); }
        }

        private decimal cash;

        public decimal Cash
        {
            get { return cash; }
            set { Set(nameof(Cash), ref cash, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { Set(nameof(Name), ref name, value); }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { Set(nameof(Date), ref date, value); }
        }
    }
}
