using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiEasyMission.Domain.Entities
{
    public class Claim
    {

        public int claimId { get; set; }
        public string TitleClaims { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        //foreign key
        public int? id_Member { get; set; }
        //Navigation property
        public virtual Member member { get; set; }
    }
}
