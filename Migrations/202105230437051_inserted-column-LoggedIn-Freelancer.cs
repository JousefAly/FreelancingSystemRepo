namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertedcolumnLoggedInFreelancer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Freelancers", "LoggedIn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Freelancers", "LoggedIn");
        }
    }
}
