namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedClientProposalstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientProposals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.ClientPosts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClientPosts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID);
            
            DropTable("dbo.ClientProposals");
        }
    }
}
