namespace Calculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalcResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        arg1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        arg2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        operation = c.String(),
                        operationTime = c.DateTime(nullable: false),
                        result = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalcResults");
        }
    }
}
