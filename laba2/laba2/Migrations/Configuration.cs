using System;
using laba2.Model;
using System.Data.Entity.Migrations;
using laba2.DB;

namespace laba2.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<laba2.DB.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BankContext context)
        {
            context.Accounts.AddOrUpdate(x => x.Id,
                new Account { Id = 1, Name = "Valdimir", MonthlyIncome = 1000, TotalCash = 1000 },
                new Account { Id = 2, Name = "Bill", TotalCash = 2000, MonthlyIncome = 2000 });

            context.Costs.AddOrUpdate(x => x.Id, 
                new Cost { AccountId = 1, Id = 1, Cash = 300, Name = "Appartment rent", Date = new DateTime(2016, 12, 21)},
                new Cost { AccountId = 1, Id = 2, Cash = 100, Name = "Food goods", Date = new DateTime(2016, 12, 20) });

            context.Incomes.AddOrUpdate(x => x.Id,
                new Income { AccountId = 1, Cash = 1000, Name = "Monthely rate", Date = new DateTime(2016, 12, 1) });
        }
    }
}