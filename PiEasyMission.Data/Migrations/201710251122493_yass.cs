namespace PiEasyMission.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "profilePhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "profilePhoto");
        }
    }
}
