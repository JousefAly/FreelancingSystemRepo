namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigupdatev1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        LoggedIn = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.ClientPosts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID);
            
            CreateTable(
                "dbo.FrSavedPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        FreeLancerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobPostRates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Clients", "LoggedIn", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobPosts", "FreelancerId", c => c.Int(nullable: false));
            AddColumn("dbo.JobPosts", "Approved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Freelancers", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Freelancers", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.JobPosts", "Approved");
            DropColumn("dbo.JobPosts", "FreelancerId");
            DropColumn("dbo.Clients", "LoggedIn");
            DropTable("dbo.JobPostRates");
            DropTable("dbo.FrSavedPosts");
            DropTable("dbo.ClientPosts");
            DropTable("dbo.Admins");
        }
    }
}
