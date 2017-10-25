namespace PiEasyMission.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Easy1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "SkillLevel", c => c.Int(nullable: false));
            DropColumn("dbo.Skills", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Skills", "SkillLevel");
        }
    }
}
