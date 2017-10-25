using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PiEasyMission.Domain.Entities;

namespace PiEasyMission.Data.Configurations
{
    class MemberConfiguration : EntityTypeConfiguration<Member>
    {
        public MemberConfiguration()
        {
            HasKey(c => c.MemberId);
        }
    }
}
