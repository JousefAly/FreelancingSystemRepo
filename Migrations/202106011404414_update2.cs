namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "FirstName", c => c.String());
            AlterColumn("dbo.Admins", "LastName", c => c.String());
            AlterColumn("dbo.Admins", "UserName", c => c.String());
            AlterColumn("dbo.Admins", "Password", c => c.String());
            AlterColumn("dbo.Admins", "Email", c => c.String());
            AlterColumn("dbo.Admins", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Clients", "FirstName", c => c.String());
            AlterColumn("dbo.Clients", "LastName", c => c.String());
            AlterColumn("dbo.Clients", "UserName", c => c.String());
            AlterColumn("dbo.Clients", "Password", c => c.String());
            AlterColumn("dbo.Clients", "Email", c => c.String());
            AlterColumn("dbo.Clients", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Freelancers", "FirstName", c => c.String());
            AlterColumn("dbo.Freelancers", "LastName", c => c.String());
            AlterColumn("dbo.Freelancers", "UserName", c => c.String());
            AlterColumn("dbo.Freelancers", "Password", c => c.String());
            AlterColumn("dbo.Freelancers", "Email", c => c.String());
            AlterColumn("dbo.Freelancers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Freelancers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Freelancers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "FirstName", c => c.String(nullable: false));
        }
    }
}
