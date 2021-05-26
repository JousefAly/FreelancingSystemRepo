namespace FreelancingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class back : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proposals", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proposals", "Content", c => c.String(nullable: false));
        }
    }
}
