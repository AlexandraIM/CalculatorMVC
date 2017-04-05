namespace Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalcResults", "operationTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalcResults", "operationTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
