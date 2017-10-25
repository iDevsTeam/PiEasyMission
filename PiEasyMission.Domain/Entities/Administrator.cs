using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PiEasyMission.Domain.Entities
{
    public class Administrator
    {
        public int AdministratorId { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
