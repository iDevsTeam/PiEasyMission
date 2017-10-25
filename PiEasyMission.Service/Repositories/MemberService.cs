using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiEasyMission.Service.Interfaces;
using ServicesPattern;
using PiEasyMission.Data.Infrastructure;
using PiEasyMission.Domain.Entities;

namespace PiEasyMission.Service.Repositories
{
    public class MemberService : Service<Member>, IMemberService
    {
        public static IDataBaseFactory dbFactory;
        public static IUnitOfWork myUnit;

        public MemberService() : base(myUnit)
        {
            dbFactory = new DataBaseFactory();
            myUnit = new UnitOfWork(dbFactory);
        }

        public void createMember(Member i)
        {
            myUnit.getRepository<Member>().Add(i);
            myUnit.Commit();
        }

        public void deleteMember(Member i)
        {
            myUnit.getRepository<Member>().Delete(i);
            myUnit.Commit();
        }

        public void deleteMemberById(int id)
        {
            Member i = myUnit.getRepository<Member>().GetById(id);
            myUnit.getRepository<Member>().Delete(i);
            myUnit.Commit();
        }

        public List<Member> getAllMember()
        {
            return myUnit.getRepository<Member>().getAll().ToList();
        }

        public Member getMemberById(int id)
        {
            return myUnit.getRepository<Member>().GetById(id);
        }



        public void updateMember(Member i)
        {
            myUnit.getRepository<Member>().Update(i);
            myUnit.Commit();
        }
    }
}
