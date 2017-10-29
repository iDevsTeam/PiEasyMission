using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PiEasyMission.Domain.Entities;
using PiEasyMission.Data;

namespace PiEasyMission.Data.Configurations
{
    public class BidConfiguration : EntityTypeConfiguration<Bid>
    {
        public BidConfiguration()
        { 
            //OneToMany  bid with member
            HasOptional(mb => mb.member)
                .WithMany(B => B.Bids)
                .HasForeignKey(m => m.MemberId)
                .WillCascadeOnDelete(false);




        }
    }
}
