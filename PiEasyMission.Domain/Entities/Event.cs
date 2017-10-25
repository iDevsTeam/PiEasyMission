using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiEasyMission.Domain.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Place { get; set; }
        public int? id_Member { get; set; }
        virtual public ICollection<Member> Members { get; set; }
    }
}
