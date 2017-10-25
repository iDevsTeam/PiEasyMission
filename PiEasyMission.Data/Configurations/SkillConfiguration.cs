using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PiEasyMission.Domain.Entities;

namespace PiEasyMission.Data.Configurations
{
    public class SkillConfiguration : EntityTypeConfiguration<Skill>
    {
        public SkillConfiguration()
        {
            HasMany(m => m.Members)
             .WithMany(s => s.Skills)
             .Map(m =>
             {
                 m.ToTable("MemberSkills");
                 m.MapLeftKey("Member");
                 m.MapRightKey("Skill");
             }
             );
        }
    }
}
