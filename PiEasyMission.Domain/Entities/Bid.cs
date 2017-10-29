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

       [Required]
        [DataType(DataType.Date)]
       
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
       
        public DateTime EndDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public City City { get; set; }
        public string SkillName { get; set; }


        public int? MemberId { get; set; } // nullable
        [ForeignKey("MemberId")]
        public virtual Member member { get; set; }

      
    }
}
