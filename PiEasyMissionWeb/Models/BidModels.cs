using PiEasyMission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiEasyMissionWeb.Models
{
    public class BidModels
    {
        [Key]
        public int BidId { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        [DataType(DataType.Date)]
        
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        
        public DateTime EndDate { get; set; }

       
        public string Description { get; set; }
        public City City { get; set; }
        public string SkillName { get; set; }



        // public virtual User user { get; set; }
    }
}