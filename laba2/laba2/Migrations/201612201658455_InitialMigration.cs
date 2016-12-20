namespace laba2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonName = c.String(),
                        TotalCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Costs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CostTitle = c.String(),
                        Description = c.String(),
                        Cash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncomeTitle = c.String(),
                        Description = c.String(),
                        Cash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Costs", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Incomes", new[] { "AccountId" });
            DropIndex("dbo.Costs", new[] { "AccountId" });
            DropTable("dbo.Incomes");
            DropTable("dbo.Costs");
            DropTable("dbo.Accounts");
        }
    }
}
