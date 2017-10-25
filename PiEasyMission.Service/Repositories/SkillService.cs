using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiEasyMission.Data.Infrastructure;
using PiEasyMission.Domain.Entities;
using PiEasyMission.Service.Interfaces;
using ServicesPattern;

namespace PiEasyMission.Service.Repositories
{
    public class SkillService : Service<Skill>, ISkillService
    {

        public static IDataBaseFactory dbFactory;
        public static IUnitOfWork myUnit;


        public SkillService() : base(myUnit)
        {
            dbFactory = new DataBaseFactory();
            myUnit = new UnitOfWork(dbFactory);
        }


        public void createSkill(Skill s)
        {
            myUnit.getRepository<Skill>().Add(s);
            myUnit.Commit();
        }

        public void deleteSkill(Skill s)
        {
            myUnit.getRepository<Skill>().Delete(s);
            myUnit.Commit();

        }

        public void deleteSkillById(int id)
        {
            Skill s = myUnit.getRepository<Skill>().GetById(id);
            myUnit.getRepository<Skill>().Delete(s);
            myUnit.Commit();
        }

        public List<Skill> getAllSkill()
        {
            return myUnit.getRepository<Skill>().getAll().ToList();
        }

        public Skill getSkillById(int id)
        {
            return myUnit.getRepository<Skill>().GetById(id);
        }

        public void updateSkill(Skill s)
        {
            myUnit.getRepository<Skill>().Update(s);
            myUnit.Commit();
        }
    }
}
