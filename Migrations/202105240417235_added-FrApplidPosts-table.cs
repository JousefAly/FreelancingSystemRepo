namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFrApplidPoststable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FrAppliedPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        FreelancerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FrAppliedPosts");
        }
    }
}
