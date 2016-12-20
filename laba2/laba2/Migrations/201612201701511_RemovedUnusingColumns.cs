namespace laba2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUnusingColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "PersonName");
            DropColumn("dbo.Costs", "CostTitle");
            DropColumn("dbo.Incomes", "IncomeTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incomes", "IncomeTitle", c => c.String());
            AddColumn("dbo.Costs", "CostTitle", c => c.String());
            AddColumn("dbo.Accounts", "PersonName", c => c.String());
        }
    }
}
