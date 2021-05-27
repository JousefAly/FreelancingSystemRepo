namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedclientNameJobPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "ClientName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPosts", "ClientName");
        }
    }
}
