namespace Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateResultDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalcResults", "operationTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalcResults", "operationTime", c => c.DateTime(nullable: false));
        }
    }
}
