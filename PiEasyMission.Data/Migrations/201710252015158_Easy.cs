namespace PiEasyMission.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Easy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "SkillName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bids", "SkillName");
        }
    }
}
