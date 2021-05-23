namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJobPostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPosts",
                c => new
                    {
                        JobPostID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        Discreption = c.String(),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        NumOfProposals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobPostID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobPosts");
        }
    }
}
