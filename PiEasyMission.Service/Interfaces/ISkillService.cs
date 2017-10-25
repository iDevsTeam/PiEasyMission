using PiEasyMission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiEasyMission.Service.Interfaces
{
   public interface ISkillService
    {
        void createSkill(Skill s);
        List<Skill> getAllSkill();
        void updateSkill(Skill s);
        Skill getSkillById(int id);
        void deleteSkill(Skill s);

        void deleteSkillById(int id);
    }
}
