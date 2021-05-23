namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobPostNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPosts", "Name");
        }
    }
}
