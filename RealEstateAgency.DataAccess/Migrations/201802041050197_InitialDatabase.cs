namespace RealEstateAgency.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estate",
                c => new
                    {
                        EstateID = c.Int(nullable: false, identity: true),
                        EstateName = c.String(nullable: false, maxLength: 30),
                        EstateSpace = c.Double(nullable: false),
                        EstateAdress = c.String(),
                        EstateCostOfSale = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EstateID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Estate");
        }
    }
}
