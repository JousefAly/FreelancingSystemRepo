namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProposalstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proposals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FreelancerID = c.Int(nullable: false),
                        FreelancerName = c.String(),
                        PostID = c.Int(nullable: false),
                        FreelancerBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Content = c.String(),
                        Accepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proposals");
        }
    }
}
