namespace Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDb1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalcResults", "operation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalcResults", "operation", c => c.String());
        }
    }
}
