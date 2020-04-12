namespace HSNHospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userfeedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Userfeedbacks",
                c => new
                    {
                        userfeedbackId = c.Int(nullable: false, identity: true),
                        servicesId = c.Int(nullable: false),
                        userfeedbackEmail = c.String(),
                        userfeedbackMsg = c.String(),
                    })
                .PrimaryKey(t => t.userfeedbackId)
                .ForeignKey("dbo.Services", t => t.servicesId, cascadeDelete: true)
                .Index(t => t.servicesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Userfeedbacks", "servicesId", "dbo.Services");
            DropIndex("dbo.Userfeedbacks", new[] { "servicesId" });
            DropTable("dbo.Userfeedbacks");
        }
    }
}
