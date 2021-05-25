namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPostRates", "FreelancerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPostRates", "FreelancerID");
        }
    }
}
