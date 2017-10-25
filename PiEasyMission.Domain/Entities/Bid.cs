using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PiEasyMission.Domain.Entities
{
    public class Bid
    {
        [Key]
        public int BidId { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }

        // [Required]
       // [DisplayFormat(DataFormatString = "{0=yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        //[Required]
       // [DisplayFormat(DataFormatString = "{0=yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string City { get; set; }


        public int? MemberId { get; set; } // nullable
        [ForeignKey("MemberId")]
        public virtual Member member { get; set; }

        public int? SkillId { get; set; } // nullable
        [ForeignKey("SkillId")]
        public virtual Skill skill { get; set; }
    }
}
