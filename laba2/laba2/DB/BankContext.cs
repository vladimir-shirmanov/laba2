using System.Data.Entity;
using laba2.Model;

namespace laba2.DB
{
    public class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<Cost> Costs { get; set; }
    }
}