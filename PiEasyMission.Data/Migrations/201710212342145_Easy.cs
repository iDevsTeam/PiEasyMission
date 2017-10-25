namespace PiEasyMission.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Easy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "user_UserId", "dbo.Users");
            DropForeignKey("dbo.Claims", "user_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Bids", new[] { "user_UserId" });
            DropIndex("dbo.Users", new[] { "Event_EventId" });
            DropIndex("dbo.Claims", new[] { "user_UserId" });
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdministratorId = c.Int(nullable: false, identity: true),
                        lastName = c.String(nullable: false),
                        firstName = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdministratorId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        lastName = c.String(nullable: false),
                        firstName = c.String(nullable: false),
                        birthday = c.DateTime(nullable: false),
                        phone_num = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        gender = c.String(nullable: false),
                        address = c.String(nullable: false),
                        skills = c.String(),
                        profilePhoto = c.Binary(),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
            CreateTable(
                "dbo.MemberSkills",
                c => new
                    {
                        Member = c.Int(nullable: false),
                        Skill = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member, t.Skill })
                .ForeignKey("dbo.Skills", t => t.Member, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Skill, cascadeDelete: true)
                .Index(t => t.Member)
                .Index(t => t.Skill);
            
            AddColumn("dbo.Bids", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bids", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bids", "MemberId", c => c.Int());
            AddColumn("dbo.Bids", "SkillId", c => c.Int(nullable: false));
            AddColumn("dbo.Claims", "member_MemberId", c => c.Int());
            AddColumn("dbo.Skills", "MyProperty", c => c.Int(nullable: false));
            CreateIndex("dbo.Bids", "MemberId");
            CreateIndex("dbo.Bids", "SkillId");
            CreateIndex("dbo.Claims", "member_MemberId");
            AddForeignKey("dbo.Bids", "MemberId", "dbo.Members", "MemberId");
            AddForeignKey("dbo.Bids", "SkillId", "dbo.Skills", "SkillId");
            AddForeignKey("dbo.Claims", "member_MemberId", "dbo.Members", "MemberId");
            DropColumn("dbo.Bids", "datebebut");
            DropColumn("dbo.Bids", "datefin");
            DropColumn("dbo.Bids", "Topic");
            DropColumn("dbo.Bids", "user_UserId");
            DropColumn("dbo.Claims", "user_UserId");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Claims", "user_UserId", c => c.Int());
            AddColumn("dbo.Bids", "user_UserId", c => c.Int());
            AddColumn("dbo.Bids", "Topic", c => c.String());
            AddColumn("dbo.Bids", "datefin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bids", "datebebut", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Members", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Claims", "member_MemberId", "dbo.Members");
            DropForeignKey("dbo.Bids", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.Bids", "MemberId", "dbo.Members");
            DropForeignKey("dbo.MemberSkills", "Skill", "dbo.Members");
            DropForeignKey("dbo.MemberSkills", "Member", "dbo.Skills");
            DropIndex("dbo.MemberSkills", new[] { "Skill" });
            DropIndex("dbo.MemberSkills", new[] { "Member" });
            DropIndex("dbo.Claims", new[] { "member_MemberId" });
            DropIndex("dbo.Members", new[] { "Event_EventId" });
            DropIndex("dbo.Bids", new[] { "SkillId" });
            DropIndex("dbo.Bids", new[] { "MemberId" });
            DropColumn("dbo.Skills", "MyProperty");
            DropColumn("dbo.Claims", "member_MemberId");
            DropColumn("dbo.Bids", "SkillId");
            DropColumn("dbo.Bids", "MemberId");
            DropColumn("dbo.Bids", "EndDate");
            DropColumn("dbo.Bids", "StartDate");
            DropTable("dbo.MemberSkills");
            DropTable("dbo.Members");
            DropTable("dbo.Administrators");
            CreateIndex("dbo.Claims", "user_UserId");
            CreateIndex("dbo.Users", "Event_EventId");
            CreateIndex("dbo.Bids", "user_UserId");
            AddForeignKey("dbo.Users", "Event_EventId", "dbo.Events", "EventId");
            AddForeignKey("dbo.Claims", "user_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Bids", "user_UserId", "dbo.Users", "UserId");
        }
    }
}
