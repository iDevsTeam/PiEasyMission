using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiEasyMission.Domain.Entities;
using System.Data.Entity;
using PiEasyMission.Data.Configurations;


namespace PiEasyMission.Data
{
    public class PiEasyMissionContext : DbContext
    {
        public PiEasyMissionContext() : base("EasyMissionBase")
        {
                
        }

        public DbSet<Bid> Bids { get; set; }
        public DbSet<Claim> Claims { get; set; }
      //  public DbSet<Forum> Forums { get; set; }
        public DbSet<Event> Events { get; set; }
       public DbSet<Skill> Skills { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Administrator> Admin { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MemberConfiguration());
            modelBuilder.Configurations.Add(new BidConfiguration());
            modelBuilder.Configurations.Add(new SkillConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new ForumConfiguration());
        }

    }
}
