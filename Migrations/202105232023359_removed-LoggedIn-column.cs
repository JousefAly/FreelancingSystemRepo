namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedLoggedIncolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "LoggedIn");
            DropColumn("dbo.Clients", "LoggedIn");
            DropColumn("dbo.Freelancers", "LoggedIn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Freelancers", "LoggedIn", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "LoggedIn", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "LoggedIn", c => c.Boolean(nullable: false));
        }
    }
}
