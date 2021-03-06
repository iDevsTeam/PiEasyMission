﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace PiEasyMission.Domain.Entities
{
   public class Member
    {
        public int MemberId { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0=yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime birthday { get; set; }
        [Required]
        public string phone_num { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]

        public string gender { get; set; }
        [Required]
        public string address { get; set; }
        public string skills { get; set; }
        public byte[] profilePhoto { get; set; }
        virtual public ICollection<Bid> Bids { get; set; }
        virtual public ICollection<Skill> Skills { get; set; }
    }
}
