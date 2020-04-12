namespace HSNHospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbacktable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        feedbackId = c.Int(nullable: false, identity: true),
                        feedbackEmail = c.String(),
                        feedbackMsg = c.String(),
                    })
                .PrimaryKey(t => t.feedbackId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
