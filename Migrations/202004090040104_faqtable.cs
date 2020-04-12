namespace HSNHospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faqtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        faqId = c.Int(nullable: false, identity: true),
                        departmentId = c.Int(nullable: false),
                        faqQuestion = c.String(),
                        faqAnswer = c.String(),
                    })
                .PrimaryKey(t => t.faqId)
                .ForeignKey("dbo.Departments", t => t.departmentId, cascadeDelete: true)
                .Index(t => t.departmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Faqs", "departmentId", "dbo.Departments");
            DropIndex("dbo.Faqs", new[] { "departmentId" });
            DropTable("dbo.Faqs");
        }
    }
}
