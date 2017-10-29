using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiEasyMission.Domain.Entities
{
   public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [Required(ErrorMessage = "You must enter your skill's name")]
        [MinLength(1, ErrorMessage = "Your skill's name should be at least one caracter")]
        [Display(Name = "Name")]
        public string SkillName { get; set; }
        [Display(Name = "Level")]
        public int SkillLevel { get; set; }

        public virtual ICollection<Member> Members { get; set; }
       
    }
}
