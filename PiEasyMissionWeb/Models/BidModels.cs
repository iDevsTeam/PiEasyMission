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

        public DateTime StartDate { get; set; }

      
        public DateTime EndDate { get; set; }

       
        public string Description { get; set; }
        public string City { get; set; }



       // public virtual User user { get; set; }
    }
}