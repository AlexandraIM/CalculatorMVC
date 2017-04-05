namespace Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDb2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalcResults", "arg1", c => c.Int(nullable: false));
            AlterColumn("dbo.CalcResults", "arg2", c => c.Int(nullable: false));
            AlterColumn("dbo.CalcResults", "result", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalcResults", "result", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CalcResults", "arg2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CalcResults", "arg1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
