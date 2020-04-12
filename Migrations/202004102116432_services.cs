namespace HSNHospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class services : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        servicesId = c.Int(nullable: false, identity: true),
                        servicesName = c.String(),
                    })
                .PrimaryKey(t => t.servicesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
        }
    }
}
