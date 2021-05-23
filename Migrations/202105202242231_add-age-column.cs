namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addagecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Freelancers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Freelancers", "Age");
        }
    }
}
