using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PiEasyMission.Domain.Entities;
using System.Threading.Tasks;

namespace PiEasyMission.Service.Interfaces
{
   public  interface IMemberService : ServicesPattern.IService<Member>
    {
        void createMember(Member i);
        List<Member> getAllMember();
        void updateMember(Member i);
        Member getMemberById(int id);
        void deleteMember(Member i);

        void deleteMemberById(int id);
    }
}
